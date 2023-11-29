using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadAtivator : MonoBehaviour
{


    player player;

    public void LateUpdate()
    {
        player = FindObjectOfType(typeof(player)) as player;
    }

    public void Interaction()
    {
        player.EnterInKeypad();
    }
}
