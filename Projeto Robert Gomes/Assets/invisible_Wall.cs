using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class invisible_Wall : MonoBehaviour
{
    public GameObject balde, luva, esfregao, sabao;

    PhotonView phview;

    // Update is called once per frame
    void Update()
    {
        if ( balde.activeSelf == false && luva.activeSelf == false && esfregao.activeSelf == false && sabao.activeSelf == false)
        {
            phview.RPC("DestroyRPC", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void DestroyRPC()
    {
        gameObject.SetActive(false);
    }
}
