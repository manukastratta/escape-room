using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RHL.Scripts.Common.Properties
{
    public class ChangeText : MonoBehaviour
    {
        [SerializeField]
        private TextMesh textMesh;

        [SerializeField]
        private string exampleText;

        private int exampleCount = 0;

        public void SetExampleText()
        {
            exampleCount++;
            ChangeTextMeshText(exampleText + " " + exampleCount.ToString());
        }
        
        public void ChangeTextMeshText(string value)
        {
            textMesh.text = value;
        }
    }
}

