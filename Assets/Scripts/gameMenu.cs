using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMenu : MonoBehaviour
{
    public GameObject menu;
    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu.activeInHierarchy)
            {
                menu.SetActive(false);
                ResumeGame();
            }
            else
            {
                menu.SetActive(true);
                PauseGame();
            }
        }
        
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
}
