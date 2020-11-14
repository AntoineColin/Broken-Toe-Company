using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class BaseCharacter : MonoBehaviour
{
    public enum Skill { VILLAGER, FISHER, HUNTER, WARRIOR, MAGE, NECROMANCER, COOK, PALADIN, DEMONIST, ARTIFICER, GATHERER, TRESORHUNTER, BARBARIAN, SPRINTER, SAGE, PRINCESS, THIEF, STRATEGIST, JUDGE, TANK, SCOUT, TAXCOLLECTOR}
    public Skill currentSkill = Skill.VILLAGER;

    public string surname;
    [Range(-3, 3)]
    public int strength;
    [Range(-3, 3)]
    public int speed;
    [Range(-3, 3)]
    public int mind;

    Text strengthText, speedText, mindText;

    void Start()
    {
        strengthText = transform.Find("StrengthText").GetComponent<Text>();
        speedText = transform.Find("SpeedText").GetComponent<Text>();
        mindText = transform.Find("MindText").GetComponent<Text>();
        UpdateStrengthText();
        UpdateSpeedText();
        UpdateMindText();
    }

    void UpdateStrengthText()
    {
        if(strength > 0)
        {
            strengthText.text = "Strong";
            strengthText.color = Color.green;
        }else if(strength < 0)
        {
            strengthText.text = "Weak";
            strengthText.color = Color.red;
        }
        else
        {
            strengthText.text = "Neutral";
            strengthText.color = Color.white;
        }
        for (int i = 1; i < Mathf.Abs(strength); i++)
        {
            strengthText.text = strengthText.text + " +";
        }
    }

    void UpdateSpeedText()
    {
        if(speed > 0)
        {
            speedText.text = "Strong";
            speedText.color = Color.green;
        }else if(speed < 0)
        {
            speedText.text = "Weak";
            speedText.color = Color.red;
        }
        else
        {
            speedText.text = "Neutral";
            speedText.color = Color.white;
        }
        for (int i = 1; i < Mathf.Abs(speed); i++)
        {
            speedText.text = speedText.text + " +";
        }
    }

    void UpdateMindText()
    {
        if(mind > 0)
        {
            mindText.text = "Strong";
            mindText.color = Color.green;
        }else if(mind < 0)
        {
            mindText.text = "Weak";
            mindText.color = Color.red;
        }
        else
        {
            mindText.text = "Neutral";
            mindText.color = Color.white;
        }
        for (int i = 1; i < Mathf.Abs(mind); i++)
        {
            mindText.text = mindText.text + " +";
        }
    }

    void JoinCompany()
    {

    }

    public void LeaveCompany()
    {

    }

    void Die()
    {

    }

    #region Static

    public static GameObject GenerateCharacter()
    {
        GameObject charaObject = (GameObject)Instantiate(Resources.Load("Prefabs/CharacterPanel.prefab"));
        BaseCharacter baseCharacter = charaObject.GetComponent<BaseCharacter>();
        Array values = Enum.GetValues(typeof(Skill));
        Random random = new Random();
        baseCharacter.currentSkill = (Skill)values.GetValue(random.Next(values.Length));
        baseCharacter.strength = random.Next(-1, 2);
        baseCharacter.speed = random.Next(-1, 2);
        baseCharacter.mind = random.Next(-1, 2);
        baseCharacter.surname = "Roger";
        return charaObject;
    }

    #endregion
}
