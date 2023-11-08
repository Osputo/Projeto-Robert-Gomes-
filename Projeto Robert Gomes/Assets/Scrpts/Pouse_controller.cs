using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pouse_controller : MonoBehaviour
{
    public GameObject pause;
    player player;


    public void Continuar()
    {
        pause.SetActive(false);
        player.state = camState.normal;
        

    }
    
    public void VoltarAoMenu(string Menu)
    {
        SceneManager.LoadScene(Menu);
    }
}
 