using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public string charClass;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int baseEXP = 100;
    public int maxLevel = 100;

    public int currentHP;
    public int maxHP = 100;
    public int currentSpirit;
    public int maxSpirit = 50;
    public int strength;
    public int spiritPower;
    public int defense;
    public int speed;
    public int weapon;
    public int armor;
    public int skillPts;
    public string equippedWpn;
    public string equippedArmr;
    public string accessory1;
    public string accessory2;
    public Sprite Char;
    
    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddEXP(500);
        }
        
    }

    public void AddEXP(int expToAdd)
    {
        if(currentEXP < maxLevel)
        {
            currentEXP += expToAdd;
            if(currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -=expToNextLevel[playerLevel];
                playerLevel++;
                skillPts++;

                // Add to stats
                if(charClass == "Henshin Hero")
                {
                    strength += 2;
                    speed += 3;
                    defense += 1;
                    spiritPower += 2;
                    maxHP = Mathf.FloorToInt(maxHP * 1.02f);
                    maxSpirit = Mathf.FloorToInt(maxSpirit * 1.06f);
                }

                if(charClass == "Cane Morose")
                {
                    strength += 1;
                    speed += 1;
                    defense += 3;
                    spiritPower += 1;
                    maxHP = Mathf.FloorToInt(maxHP * 1.06f);
                    maxSpirit = Mathf.FloorToInt(maxSpirit * 1.02f);
                }

                currentHP = maxHP;
                currentSpirit = maxSpirit;
            }
        } 
        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
