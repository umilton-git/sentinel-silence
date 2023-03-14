using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    public string[] lines;
    private bool canActivate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canActivate == true && Input.GetKeyDown(KeyCode.Z))
        {
            if(!DialogueManager.instance.dialogueBox.activeInHierarchy)
            {
                DialogueManager.instance.showDialogue(lines);
                PlayerController.instance.inDialogue = true;
            }
        }

        if(PlayerController.instance.intCheck.collider != null && PlayerController.instance.intCheck.collider.gameObject == this.gameObject && PlayerController.instance.intCheck.distance <= 1)
        {
            canActivate = true;
        }
        else
        {
            canActivate = false;
        }
    }
}
