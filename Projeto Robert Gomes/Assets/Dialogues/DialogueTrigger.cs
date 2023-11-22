using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJson;

    


    public void Interaction()
    {
        DialogueManeger.GetInstance().EnterDialogueMode(inkJson);
    }
}
