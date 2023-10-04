using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class key : MonoBehaviour
{
    player player;
    PhotonView phview;
    public int id;

    // Start is called before the first frame update

    private void LateUpdate()
    {
        player = FindObjectOfType(typeof(player)) as player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interaction()
    {
        
    }
}
