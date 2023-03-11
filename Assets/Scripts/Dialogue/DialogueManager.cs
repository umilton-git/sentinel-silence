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
    public DialogueManager instance;

    public string[] dialogueLines;

    public int currentLine;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueBox.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                currentLine++;
                if(currentLine < dialogueLines.Length)
                {
                    dialogueText.text = dialogueLines[currentLine];
                }
                else
                {
                    dialogueBox.SetActive(false);
                }
            }
        }
    }
}
