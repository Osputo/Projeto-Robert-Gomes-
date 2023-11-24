using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private TextAsset inkJson2;




    public void Interaction()
    {

        Debug.Log("PInto?");
        DialogueManeger.GetInstance().EnterDialogueMode(inkJson);
    }
    public void Interaction2()
    {
        DialogueManeger.GetInstance().EnterDialogueMode(inkJson2);
    }
}
