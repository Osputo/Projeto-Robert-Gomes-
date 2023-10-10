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

    public void OnCollisionEnter(Collision collision)
    {
        phview.RPC("DestroyRPC", RpcTarget.AllBuffered);
    }

    
    

    [PunRPC]
    private void DestroyRPC()
    {
        

        if (id == 1 || id == 2 || id == 3 || id == 4)
        {

        }
        else
            gameObject.SetActive(false);
    }
}
