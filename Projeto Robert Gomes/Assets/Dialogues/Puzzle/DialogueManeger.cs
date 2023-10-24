using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

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

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
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

        currentStory.BindExternalFunction("mudarDialogo", (string diferent) => {
            Debug.Log(diferent);
        });

        ContinueStory();

    }


    private void ExitDialogueMode()
    {
        player.state = camState.normal;
        dialogueIsPlaying = false;

        animator.SetBool("IsOpen", false);

        dialogueText.text = "";


        currentStory.UnbindExternalFunction("mudarDialogo");
        
    }


    private void ContinueStory()
    {

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

            DisplayChoices();

        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length) 
        {
            Debug.LogError("More choices were given then the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);

        }

        StartCoroutine(SelectFirstChoice()); 
    }


    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);

    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
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
