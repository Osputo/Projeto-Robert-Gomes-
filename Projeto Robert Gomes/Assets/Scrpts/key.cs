using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    player player;
    // Start is called before the first frame update
    void Start()
    {
        player= FindObjectOfType(typeof(player)) as player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interaction()
    {
        gameObject.SetActive(false);
        player.chave = true;
    }
}
