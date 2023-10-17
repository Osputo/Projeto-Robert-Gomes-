using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canva : MonoBehaviour
{
    public GameObject e;
    player player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(player)) as player;
    }

    // Update is called once per frame
    void Update()
    {
        Comu();
    }

    public void Comu()
    {
        switch (player.state)
        {
            case camState.dialogue:
                break;

            case camState.normal:

                


                break;
        }

    }
}
    
