using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class GameController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(player.name, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
