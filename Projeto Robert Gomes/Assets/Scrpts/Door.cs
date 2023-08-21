using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Door : MonoBehaviour
{
    Animator anim;
    player player;

    

    // Start is called before the first frame update
    void Start()
    {
      
        anim = GetComponentInParent<Animator>();
        player = FindObjectOfType(typeof(player)) as player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Interaction()
    {
        anim.SetBool("open", !anim.GetBool("open"));
    }

    
    public void Interaction2()
    {
        anim.SetBool("open", !anim.GetBool("open"));
    }

}
