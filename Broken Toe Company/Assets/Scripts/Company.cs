using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static BaseCharacter;

public class Company : MonoBehaviour
{
    public List<BaseCharacter> characters;

    enum SelectionMethod { RANDOM, FIRST, LAST}

    void Start()
    {
        
    }

    void AddCharacter(BaseCharacter character)
    {
        characters.Add(character);
    }

    void RemoveCharacter(Func<BaseCharacter, bool> conditionToBeRemoved, int count = 1, SelectionMethod selectionMethod = SelectionMethod.RANDOM)
    {
        List<BaseCharacter> potentialyOut = characters.Where(conditionToBeRemoved).ToList();
        if (count > potentialyOut.Count) count = potentialyOut.Count;
        switch (selectionMethod)
        {
            case SelectionMethod.RANDOM:
                System.Random rand = new System.Random();
                while(count-- < 0) potentialyOut[rand.Next(potentialyOut.Count - 1)].LeaveCompany();
                break;
            case SelectionMethod.FIRST:
                while (count-- < 0) potentialyOut[0].LeaveCompany();
                break;
            case SelectionMethod.LAST:
                while (count-- < 0) potentialyOut[potentialyOut.Count - 1].LeaveCompany();
                break;
        }
    }

    bool hasFisher()
    {
        return characters.Any(x => x.currentSkill == Skill.FISHER);
    }

    bool hasHunter()
    {
        return characters.Any(x => x.currentSkill == Skill.HUNTER);
    }

    bool hasNecromancer()
    {
        return characters.Any(x => x.currentSkill == Skill.NECROMANCER);
    }


}
