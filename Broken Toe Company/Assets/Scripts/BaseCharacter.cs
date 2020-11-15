using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    Text strengthText, speedText, mindText, surnameText;

    static Random random = new Random();
    static string[] surnames = { "Roger", "Thierry", "Yuan Zu", "Bohort", "Toby", "Jean-Michel", "Tony", "Cynthia", "Lydia", "Karen", "Chad", "Lee", "Christiana", "Ingeborg", "Alton", "Remedios", "Laurine", "Jay", "Cedrick", "Risa", "Mirta", "Roy", "Ethelene", "Pearle", "Candyce", "Tyrell", "Jazmin", "Charlie", "Keri", "Claud", "Nobuko", "Sebrina"};

    void Start()
    {
        surnameText = transform.Find("SurnameText").GetComponent<Text>();
        strengthText = transform.Find("StrengthText").GetComponent<Text>();
        speedText = transform.Find("SpeedText").GetComponent<Text>();
        mindText = transform.Find("MindText").GetComponent<Text>();
        UpdateStrengthText();
        UpdateSpeedText();
        UpdateMindText();
        UpdateSurnameText();
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
            speedText.text = "Fast";
            speedText.color = Color.green;
        }else if(speed < 0)
        {
            speedText.text = "Slow";
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
            mindText.text = "Smart";
            mindText.color = Color.green;
        }else if(mind < 0)
        {
            mindText.text = "Idiot";
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

    void UpdateSurnameText()
    {
        surnameText.text = surname + " " + currentSkill.ToString().ToLower();
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
        GameObject charaObject = (GameObject)Instantiate(Resources.Load("CharacterPanel"));
        BaseCharacter baseCharacter = charaObject.GetComponent<BaseCharacter>();
        Array values = Enum.GetValues(typeof(Skill));
        baseCharacter.currentSkill = (Skill)values.GetValue(random.Next(values.Length));
        baseCharacter.strength = random.Next(-1, 2);
        baseCharacter.speed = random.Next(-1, 2);
        baseCharacter.mind = random.Next(-1, 2);
        baseCharacter.surname = surnames[random.Next(surnames.Length)];
        return charaObject;
    }

    #endregion
}
