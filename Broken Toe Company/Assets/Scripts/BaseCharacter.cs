using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class BaseCharacter : MonoBehaviour
{
    public enum Skill { VILLAGER, FISHER, HUNTER, WARRIOR, MAGE, NECROMANCER, COOK, PALADIN, DEMONIST, ARTIFICER, GATHERER, TRESORHUNTER, BARBARIAN, SPRINTER, SAGE, PRINCESS, THIEF, STRATEGIST, JUDGE, TANK, SCOUT, TAXCOLLECTOR }
    public Skill currentSkill = Skill.VILLAGER;

    public string surname;
    [Range(0, 5)]
    public int strength;
    [Range(0, 5)]
    public int speed;
    [Range(0, 5)]
    public int mind;

    Text strengthText, speedText, mindText, surnameText;
    int price;

    static readonly Random random = new Random();
    static readonly string[] surnames = { "Roger", "Thierry", "Yuan Zu", "Bohort", "Toby", "Jean-Michel", "Tony", "Cynthia", "Lydia", "Karen", "Chad", "Lee", "Christiana", "Ingeborg", "Alton", "Remedios", "Laurine", "Jay", "Cedrick", "Risa", "Mirta", "Roy", "Ethelene", "Pearle", "Candyce", "Tyrell", "Jazmin", "Charlie", "Keri", "Claud", "Nobuko", "Sebrina" };

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
        strengthText.text = strengthText.text + " " + strength;
    }

    void UpdateSpeedText()
    {
        speedText.text = speedText.text + " " + speed;
    }

    void UpdateMindText()
    {
        mindText.text = mindText.text + " " + mind;
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
        baseCharacter.strength = random.Next(0, 3);
        baseCharacter.speed = random.Next(0, 3);
        baseCharacter.mind = random.Next(0, 3);
        baseCharacter.surname = surnames[random.Next(surnames.Length)];
        baseCharacter.price = baseCharacter.strength * 5 + baseCharacter.speed * 5 + baseCharacter.mind * 5;
        return charaObject;
    }

    #endregion
}
