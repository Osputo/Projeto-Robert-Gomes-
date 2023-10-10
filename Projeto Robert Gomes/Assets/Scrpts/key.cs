using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class key : MonoBehaviour
{
    player player;
    PhotonView phview;
    public int id;
    public bool activado;


    private void Start()
    {
        phview = GetComponent<PhotonView>(); ;    
    }

    public void Destroy()
    {
        phview.RPC("DestroyRPC", RpcTarget.AllBuffered);
    }


    [PunRPC]
    private void DestroyRPC()
    {
        gameObject.SetActive(false);
    }
}
