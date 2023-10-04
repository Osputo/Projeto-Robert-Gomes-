using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pouse_controller : MonoBehaviour
{
    public GameObject painel_de_pause;


    
    void Start()
    {
        painel_de_pause.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausarJogo();
        }
    }
    
    private void PausarJogo()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            painel_de_pause.SetActive(true);
        }
        else if (Time.timeScale == 0) 
        {
            Time.timeScale = 1;
            painel_de_pause.SetActive(false);
        }
    }
    public void Continuar()
    {
        PausarJogo();
    }
    
    public void VoltarAoMenu(string Menu)
    {
        SceneManager.LoadScene(Menu);
    }
}
