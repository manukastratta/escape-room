using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace RHL.Scripts.Networking
{
    public class RHLNetworkedAvatar : MonoBehaviourPun
    {
        public FollowTransform Head;
        public FollowTransform RHand;
        public FollowTransform LHand;

        public void Start()
        {
            if (photonView.IsMine)
            {
                Head.gameObject.GetComponent<Renderer>().enabled = false;
                Head.gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            }
        }
    }
}

