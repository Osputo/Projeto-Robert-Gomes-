using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManeger : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public float speedText;

    public Animator animator;

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
    }
}
