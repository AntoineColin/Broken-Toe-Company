using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public string surname;
    [Range(-3, 3)]
    public int strength;
    [Range(-3, 3)]
    public int speed;
    [Range(-3, 3)]
    public int mind;

    public enum Skill { VILLAGER, FISHER, HUNTER, WARRIOR, MAGE, NECROMANCER, COOK, PALADIN, DEMONIST, ARTIFICER, GATHERER, TRESORHUNTER, BARBARIAN, SPRINTER, SAGE, PRINCESS, THIEF, STRATEGIST, JUDGE, TANK, SCOUT}
    public Skill currentSkill = Skill.VILLAGER;

    void Start()
    {
        System.Random rand = new System.Random();
        int choice = rand.Next(typeof(Skill).GetMembers().Length - 1);

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

    //public static GameObject GenerateCharacter()
    //{
    //    GameObject chara = Instantiate()
    //    return new Character();
    //}

    #endregion
}
