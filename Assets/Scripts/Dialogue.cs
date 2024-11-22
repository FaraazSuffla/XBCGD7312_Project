using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float dialogueSpeed;
    public int trackDialogue;

    private void Start()
    {
        dialogueText.text = string.Empty;
        DialogueStart();
    }

    private void Update()
    {
        
        
    }

    public void DialogueStart()
    {
        trackDialogue = 0;
        StartCoroutine(TypeDialogue());
    }

    public void DialogueNextLine()
    {
        if (trackDialogue < dialogueLines.Length - 1)
        {
            trackDialogue++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            gameObject.SetActive(false);
        } 
    }

    IEnumerator TypeDialogue()
    {
        foreach (char c in dialogueLines[trackDialogue].ToCharArray()) 
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(dialogueSpeed);

        }
    }





}
