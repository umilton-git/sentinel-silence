using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public TMP_Text nameText;
    public GameObject dialogueBox;
    public GameObject nameBox;
    private bool justStarted;
    public static DialogueManager instance;

    public string[] dialogueLines;

    public int currentLine;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        justStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueBox.activeInHierarchy)
        {
            if(Input.GetKeyUp(KeyCode.Z))
            {
                if(!justStarted)
                {
                    currentLine++;
                    if(currentLine < dialogueLines.Length)
                    {
                        checkName();
                        dialogueText.text = dialogueLines[currentLine];
                    }
                    else
                    {
                        dialogueBox.SetActive(false);
                        PlayerController.instance.inDialogue= false;
                    }
                } else

                {
                    justStarted = false;
                }
            }
        }
    }

    public void showDialogue(string[] convo) 
    {
        dialogueLines = convo;
        currentLine = 0;
        checkName();
        dialogueText.text = dialogueLines[currentLine];
        dialogueBox.SetActive(true);
        justStarted = true;
    }

    public void checkName()
    {
        if(dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
