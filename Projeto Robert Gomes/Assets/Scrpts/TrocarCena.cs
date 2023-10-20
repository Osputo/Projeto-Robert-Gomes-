using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    public string NomedaCena; 

    private void OnEnable()
    {
        SceneManager.LoadScene(NomedaCena);
    }
}
