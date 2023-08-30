using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class securityCamera : MonoBehaviour
{

    Animator anim;
    PhotonView phview;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            phview.RPC("LigthRCP", RpcTarget.AllBuffered);
            
        }
    }




    [PunRPC]
    public void LigthRCP()
    {
        anim.SetBool("Close", !anim.GetBool("Close"));
    }

}
