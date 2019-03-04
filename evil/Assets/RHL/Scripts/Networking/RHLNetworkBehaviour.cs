using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RHLNetworkBehaviour : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * TEMPLATE FOR NETWORKED FUNCTIONS
    public void CallOnNetwork (string example)
    {
        // pass in the name of your functions, which people you want to execute the function, and the arguments
        photonView.RPC("NetworkCall", RpcTarget.All, example);
    }

    [PunRPC]
    private void NetworkCall(string example)
    {
        // all networks will now print the example
        Debug.Log(example);
    }
    */

    public void CallNetworkChangeColor()
    {
        photonView.RPC("RPCNetworkChangeColor", RpcTarget.All, Random.value, Random.value, Random.value);
    }

    public void SetNetworkColor(Color c)
    {
        photonView.RPC("RPCNetworkChangeColor", RpcTarget.All, c.r, c.g, c.b);
    }

    [PunRPC]
    public void RPCNetworkChangeColor(float r, float g, float b)
    {
        GetComponent<Renderer>().material.color = new Color(r, g, b);
    }
}
