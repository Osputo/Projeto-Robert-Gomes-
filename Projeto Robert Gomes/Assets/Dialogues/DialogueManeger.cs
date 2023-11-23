using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;


public class DialogueManeger : MonoBehaviour
{
    private static DialogueManeger instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;

    Animator anim;

    private bool dialogueIsPlaying;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more then one Dialogue Maneger in the scene");
        }
        anim = GetComponent<Animator>();

        instance = this; 
    }


    public static DialogueManeger GetInstance()
    {
        return instance;
    }


    private void Start()
    {

        
        dialogueIsPlaying = false;
    }

    private void Update()
    {
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying) 
        {
            return;
        }
        // handle continuing to the next line in the dialogue when submit is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        anim.SetBool("IsOpen", !anim.GetBool("IsOpen"));

        ContinueStory();

    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying=false;
        anim.SetBool("IsOpen", !anim.GetBool("IsOpen"));
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }
}
