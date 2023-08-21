using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriger : MonoBehaviour
{

    public Dialogue dialogue;

    public void Interaction()
    {
        FindObjectOfType<DialogueManeger>().StartDialogue(dialogue);
    }

    public void Interaction2()
    {
        FindObjectOfType<DialogueManeger>().StartDialogue(dialogue);
    }

}
