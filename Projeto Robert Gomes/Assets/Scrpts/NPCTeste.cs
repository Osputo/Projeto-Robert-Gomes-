using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTeste : MonoBehaviour
{
    player player;
    Canva canva;
    public string npcFalas;

    void Start()
    {
        player = FindObjectOfType(typeof(player)) as player;
        canva = FindObjectOfType(typeof(Canva)) as Canva;

    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void Interaction()
    {
        player.state = camState.dialogue;
    }

    public void Interaction2()
    {
        player.state = camState.dialogue;
    }
}
