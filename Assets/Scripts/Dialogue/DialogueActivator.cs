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
        if(canActivate == true)
        {
            Debug.Log("True");
        }
        else
        {
            Debug.Log("False");
        }
        if(PlayerController.intCheck.collider.gameObject == this.gameObject && PlayerController.intCheck.distance <= 1)
        {
            canActivate = true;
        }
        else
        {
            canActivate = false;
        }
    }
}
