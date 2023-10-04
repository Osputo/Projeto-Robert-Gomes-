using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CanvasName : MonoBehaviour
{
    PhotonView phView;
    TMP_Text tmtext;

    private void Awake()
    {
        phView = GetComponent<PhotonView>();
        tmtext = GetComponentInChildren<TMP_Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        phView.RPC("SetNick", RpcTarget.AllBuffered, PlayerPrefs.GetString("Nick"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [PunRPC]
    public void SetNick(string nick)
    {
        //phView.Controller.NickName = nick;
        phView.Controller.NickName = PhotonNetwork.NickName;
        tmtext.text = phView.Controller.NickName;
    }
}
