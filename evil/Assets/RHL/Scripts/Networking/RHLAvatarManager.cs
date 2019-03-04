using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace RHL.Scripts.Networking
{

    public class RHLAvatarManager : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private Transform CameraHead;

        [SerializeField]
        private Transform LControllerAnchor;

        [SerializeField]
        private Transform RControllerAnchor;

        // Start is called before the first frame update
        void Start()
        {

        }

        public override void OnJoinedRoom()
        {
            //Debug.Log("PUN RHL: OnJoinedRoom() called by PUN. Now this client is in a room.");
            GameObject avatar = PhotonNetwork.Instantiate("RHLNetworkedAvatarPrefab", Vector3.zero, Quaternion.identity);
            //GameObject avatar = PhotonNetwork.Instantiate("RHLNetworkedAvatar", Vector3.zero, Quaternion.identity);
            RHLNetworkedAvatar networkedAvatar = avatar.GetComponent<RHLNetworkedAvatar>();
            networkedAvatar.Head.SetFollowTransform(CameraHead);
            networkedAvatar.RHand.SetFollowTransform(RControllerAnchor);
            networkedAvatar.LHand.SetFollowTransform(LControllerAnchor);

            networkedAvatar.RHand.gameObject.SetActive(RControllerAnchor.gameObject.activeInHierarchy);
            networkedAvatar.LHand.gameObject.SetActive(LControllerAnchor.gameObject.activeInHierarchy);
        }
    }

}
