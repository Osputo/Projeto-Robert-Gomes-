using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class OnlineController : MonoBehaviour
{
    [Header("Online")]
    public GameObject kitGameplay1;
    public GameObject kitGameplay2;

    public Transform playerSpawner;

    NetworkController online;

    void Start()
    {
        if (PhotonNetwork.PlayerList.Length == 1)
            PhotonNetwork.Instantiate(kitGameplay1.name, playerSpawner.position, kitGameplay1.transform.rotation, 0);
        else
            PhotonNetwork.Instantiate(kitGameplay2.name, playerSpawner.position, kitGameplay2.transform.rotation, 0);
    }
}
