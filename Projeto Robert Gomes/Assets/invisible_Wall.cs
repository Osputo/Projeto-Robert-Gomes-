using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class invisible_Wall : MonoBehaviour
{
    public GameObject balde, luva, esfregao, sabao, poca, placa, dialogue1, dialogue2, dialogue3, dialogue4;

    PhotonView phview;


    private void Start()
    {
        phview = GetComponent<PhotonView>();
    }
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
        dialogue1.gameObject.SetActive(false);
        dialogue2 .gameObject.SetActive(true);
        dialogue3.gameObject.SetActive(false);
        dialogue4.gameObject.SetActive(true);
        placa.gameObject.SetActive(false);
        poca.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
