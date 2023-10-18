using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriger : MonoBehaviour
{

    public Dialogue dialogue;


    [Header("ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextAsset inkJSON2;

    public void Interaction()
    {
        //FindObjectOfType<DialogueManeger>().StartDialogue(dialogue);

        DialogueManeger.GetInstance().EnterDialogueMode(inkJSON);

    }

    public void Interaction2()
    {

        Debug.Log("TA CHEGANDO");
        DialogueManeger.GetInstance().EnterDialogueMode(inkJSON2);
        //FindObjectOfType<DialogueManeger>().StartDialogue(dialogue);
    }

}
