using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriger : MonoBehaviour
{

    public Dialogue dialogue;


    [Header("ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public void Interaction()
    {
        //FindObjectOfType<DialogueManeger>().StartDialogue(dialogue);

        Debug.Log(inkJSON.text);

    }

    public void Interaction2()
    {
        //FindObjectOfType<DialogueManeger>().StartDialogue(dialogue);
    }

}
