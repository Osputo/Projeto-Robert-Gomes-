using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Door : MonoBehaviour
{
    Animator anim;
    player player;
    PhotonView phview;


    // Start is called before the first frame update
    void Start()
    {
      
        anim = GetComponent<Animator>();
        player = FindObjectOfType(typeof(player)) as player;
        phview = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    public void Interaction()
    {
        phview.RPC("DoorRPC", RpcTarget.AllBuffered);
    }

    
    public void Interaction2()
    {
        phview.RPC("DoorRPC", RpcTarget.AllBuffered);
    }


    [PunRPC]
    public void DoorRPC()
    {
        anim.SetBool("open", !anim.GetBool("open"));
    }

}
