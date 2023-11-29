using DialogueSystemWithText;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] private DialogueUIController _dialogueUIController;
    [SerializeField] private DialogueUIController _dialogueUIController1_5;
    [SerializeField] private DialogueUIController _dialogueUIController2;
    public void Interaction()
    {

        _dialogueUIController.ShowDialogueUI();

        _dialogueUIController1_5.ShowDialogueUI();
        
    }
    public void Interaction2()
    {
        _dialogueUIController2.ShowDialogueUI();
    }
}
