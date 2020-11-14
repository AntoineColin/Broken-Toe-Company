using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    string surname;
    int strength;
    int speed;
    int mind;

    public enum Skill { VILLAGER, FISHER, HUNTER, WARRIOR, MAGE, NECROMANCER, COOK, PALADIN, DEMONIST, ARTIFICER, GATHERER, TRESORHUNTER, BARBARIAN, SPRINTER, SAGE, PRINCESS, THIEF, STRATEGIST, JUDGE, TANK, SCOUT}
    public Skill currentSkill = Skill.VILLAGER;

    void Start()
    {
        
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
