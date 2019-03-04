using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RHL.Scripts.Common
{
    public class LightUpAudio : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSrc;

        public static float[] samples = new float[512];
        public static float[] freqBand = new float[8];
        public static float[] highestFreq = new float[8];
        public static float[] audioBands = new float[8];

        public float volumeModifier = 0.2f;

        private Color originalColor;

        private bool alternater = true;

        // Start is called before the first frame update
        void Start()
        {
            if (audioSrc == null)
            {
                audioSrc = GetComponent<AudioSource>();
            }
            audioSrc.clip = Microphone.Start("", true, 10, 44100);
            audioSrc.Play();
            if (GetComponent<Renderer>() != null)
            {
                originalColor = GetComponent<Renderer>().material.color;
            }
        }

        void LightCube()
        {
            alternater = !alternater;
            if (!alternater)
            {
                return;
            }
            int count = 0;

            // Iterate through the 8 bins.
            for (int i = 0; i < 8; i++)
            {
                float average = 0;
                int sampleCount = (int)Mathf.Pow(2, i + 1);

                // Adding the remaining two samples into the last bin.
                if (i == 7)
                {
                    sampleCount += 2;
                }

                // Go through the number of samples for each bin, add the data to the average
                for (int j = 0; j < sampleCount; j++)
                {
                    average += samples[count];
                    count++;
                }

                // Divide to create the average, and scale it appropriately.
                average /= count;
                freqBand[i] = (i + 1) * 100 * average;
            }

            // GameObject spawnedSphere = Instantiate(spherePrefab, transform.position, transform.rotation);
            float volumeSum = 0f;
            for (int i = 0; i < freqBand.Length; i++)
            {
                // Debug.Log(freqBand[i] + " " + i);
                if (freqBand[i] > highestFreq[i])
                {
                    highestFreq[i] = freqBand[i];
                }
                audioBands[i] = freqBand[i] / highestFreq[i];
                volumeSum += audioBands[i];
            }
            // light up based on volume
            volumeSum *= volumeModifier;
            if (GetComponent<Renderer>() != null)
            {
                // networked
                GetComponent<RHLNetworkBehaviour>().SetNetworkColor(new Color(originalColor.r + volumeSum, originalColor.g + volumeSum, originalColor.b + volumeSum, originalColor.a));

                // non-networked
                // GetComponent<Renderer>().material.color = new Color(originalColor.r + volumeSum, originalColor.g + volumeSum, originalColor.b + volumeSum, originalColor.a);
            }
        }

        void GetSpectrumAudioSource()
        {
            audioSrc.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        }

        // Update is called once per frame
        void Update()
        {
            if (audioSrc.clip != null && audioSrc.isPlaying)
            {
                GetSpectrumAudioSource();
                LightCube();
            }
        }
    }
}
