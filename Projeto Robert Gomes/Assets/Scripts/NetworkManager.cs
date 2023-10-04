using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void BtnConnect()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        //menuLogin.SetActive(true);
    }
    public override void OnConnected()
    {
        print("Conectei");
    }
    public override void OnConnectedToMaster()
    {
        print("Conectei ao Master");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        print("Entrei no Lobby");
        //PhotonNetwork.CreateRoom("Room");
        //PhotonNetwork.JoinRandomRoom();
        RoomOptions options = new RoomOptions();
        //PhotonNetwork.JoinOrCreateRoom("Room" + Random.Range(100, 1000), options, null);
        //PlayerPrefs.SetString("Nick", $"Player {Random.Range(100, 1000)}");
        PhotonNetwork.NickName = $"Player {Random.Range(100, 1000)}";
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
    public override void OnCreatedRoom()
    {
        print("Criei uma sala");
    }
    public override void OnJoinedRoom()
    {
        print("Entrei na sala");
        PhotonNetwork.LoadLevel("SampleScene");
        //PhotonNetwork.Instantiate(player.name, playerSpawner.position, player.transform.rotation, 0);
        
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        print($"{otherPlayer.NickName} saiu da sala");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        
    }
}
