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
    Player2 player2;

    public bool chave;

    // Start is called before the first frame update
    void Start()
    {     
        anim = GetComponent<Animator>();      
        phview = GetComponent<PhotonView>();
        chave = false;
    }

    private void LateUpdate()
    {
        player2 = FindObjectOfType(typeof(Player2)) as Player2;
        player = FindObjectOfType(typeof(player)) as player;
    }
    // Update is called once per frame


    public void open()
    {
        chave = true;
    }

    public void Interaction()
    {

        phview.RPC("DoorRPC", RpcTarget.AllBuffered);

        GetComponent<PhotonView>().RPC("RPCInteract", RpcTarget.AllBuffered);

    }


    public void Interaction2()
    {

        phview.RPC("DoorRPC", RpcTarget.AllBuffered);
        GetComponent<PhotonView>().RPC("RPCInteract", RpcTarget.AllBuffered);

    }
    [PunRPC]
    public void DoorRPC()
    {

        if(chave == true)
        {
            anim.SetBool("open", !anim.GetBool("open"));
        }
        if(chave == false) 
        {
            anim.SetTrigger("loked");
        }
    }
}
