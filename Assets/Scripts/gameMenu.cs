using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameMenu : MonoBehaviour
{
    public GameObject menu;
    public static bool isPaused = false;
    private CharStats[] playerStats;

    public TMP_Text[] nameText, HpText, SpText, lvlText;
    public Slider[] HpSlider, SpSlider;
    public Image[] charImage;
    public GameObject[] charStatHolder;
    public Button[] menuButtons;
    public Button Tracker;
    private int trackerPos;
    private ColorBlock buttonColor;
    private ColorBlock buttonColorPressed;

    // Start is called before the first frame update
    void Start()
    {
        Tracker.transform.position = menuButtons[0].transform.position;
        trackerPos = 0;
        buttonColor = Tracker.colors;
        buttonColorPressed.normalColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu.activeInHierarchy)
            {
                menu.SetActive(false);
                trackerPos = 0;
                ResumeGame();
            }
            else
            {
                menu.SetActive(true);
                UpdateMainStats();
                PauseGame();
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && isPaused)
        {
            if(trackerPos < menuButtons.Length - 1)
            {
                trackerPos += 1;
                Tracker.transform.position = menuButtons[trackerPos].transform.position;
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && isPaused)
        {
            if(trackerPos > 0)
            {
                trackerPos -= 1;
                Tracker.transform.position = menuButtons[trackerPos].transform.position;
            }
        }

        if(Input.GetKeyDown(KeyCode.Z) && isPaused)
        {
            Tracker.colors = buttonColorPressed;   
        }

        if(Input.GetKeyUp(KeyCode.Z) && isPaused)
        {
            Tracker.colors = buttonColor;
            if(menuButtons[trackerPos].name == "Close")
            {
                menu.SetActive(false);
                trackerPos = 0;
                ResumeGame();
            } 

            if(menuButtons[trackerPos].name == "Quit")
            {
                trackerPos = 0;
                Application.Quit();
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
        Tracker.transform.position = menuButtons[trackerPos].transform.position;
        Time.timeScale = 1;
        isPaused = false;
    }

    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;

        for(int i = 0; i < playerStats.Length; i++)
        {
            if(playerStats[i].gameObject.activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);
                nameText[i].text = playerStats[i].charName;
                HpText[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
                SpText[i].text = "SP: " + playerStats[i].currentSpirit + "/" + playerStats[i].maxSpirit;
                lvlText[i].text = "Lv: " + playerStats[i].playerLevel;
                HpSlider[i].maxValue = playerStats[i].maxHP;
                HpSlider[i].value = playerStats[i].currentHP;
                SpSlider[i].maxValue = playerStats[i].maxSpirit;
                SpSlider[i].value = playerStats[i].currentSpirit;
                charImage[i].sprite = playerStats[i].Char;
            } else
            {
                charStatHolder[i].SetActive(false);
            }
        }
    }
}
