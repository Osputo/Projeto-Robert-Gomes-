using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Disconect : MonoBehaviour
{
    public void BackMenu()
    {
        //player.SetActive(false); //referencia do kit gameplay
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("MainMenu");
    }
}
