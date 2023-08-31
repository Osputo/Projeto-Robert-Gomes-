using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class key : MonoBehaviour
{
    player player;
    Player2 player2;
    PhotonView phview;

    // Start is called before the first frame update

    private void LateUpdate()
    {
        player = FindObjectOfType(typeof(player)) as player;
        player2 = FindObjectOfType(typeof(Player2)) as Player2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interaction()
    {
        gameObject.SetActive(false);
        player2.chave = true;
    }
}
