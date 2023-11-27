using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextAsset inkJSON2;




    public void Interaction()
    {

        Debug.Log("PInto?");
        DialogueManeger.GetInstance().EnterDialogueMode(inkJSON);
    }
    public void Interaction2()
    {
        DialogueManeger.GetInstance().EnterDialogueMode(inkJSON2);
    }
}
