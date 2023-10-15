using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueManeger : MonoBehaviour
{
    private static DialogueManeger instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public Animator animator;

    private bool dialogueIsPlaying;

    player player;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Maneger in the scene");
            dialogueIsPlaying = false;

        }
        instance = this;
    }

    private void LateUpdate()
    {
        player = FindObjectOfType(typeof(player)) as player;
    }

    public static DialogueManeger GetInstance()
    {
        return instance;
    }



    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        if (Input.GetButtonDown("Q"))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);

        player.state = camState.dialogue;
        dialogueIsPlaying = true;


        animator.SetBool("IsOpen", true);

        ContinueStory();

    }


    private void ExitDialogueMode()
    {
        player.state = camState.normal;
        dialogueIsPlaying = false;

        animator.SetBool("IsOpen", false);

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

    /*public TMP_Text nameText;
    public TMP_Text dialogueText;
    public float speedText;

    

    player player;

    Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        player = FindObjectOfType(typeof(player)) as player;
    }


    private void Update()
    {
        switch (player.state)
        {
            case camState.dialogue:
                if (Input.GetButtonDown("Fire2"))
                    DisplayNextSetence();

                break;
        }                                  
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        player.state = camState.dialogue;

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); 
        }

        DisplayNextSetence();
    }

    public void DisplayNextSetence()
    {
        
        
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string setence = sentences.Dequeue();

            StopAllCoroutines();

            StartCoroutine(TypeSentence(setence));
        
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(speedText);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);


        player.state = camState.normal;
    }*/









}
