using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static BaseCharacter;

public class Company : MonoBehaviour
{
    public enum SelectionMethod { RANDOM, FIRST, LAST }

    public List<BaseCharacter> characters;
    public int gold = 0;
    public int food = 0;

    public int strengthMod;
    public int speedMod;
    public int mindMod;

    [Range(1, 4)]
    public int startingCharacter = 1;

    void Start()
    {
        for (int i = 0; i< startingCharacter; i++)
        {
            GameObject goChara = GenerateCharacter();
            goChara.transform.SetParent(transform);
            AddCharacter(goChara.GetComponent<BaseCharacter>());
        }
    }

    public void AddCharacter(BaseCharacter character)
    {
        characters.Add(character);
    }

    public void RemoveCharacter(Func<BaseCharacter, bool> conditionToBeRemoved, int count = 1, SelectionMethod selectionMethod = SelectionMethod.RANDOM)
    {
        List<BaseCharacter> potentialyOut = characters.Where(conditionToBeRemoved).ToList();
        if (count > potentialyOut.Count) count = potentialyOut.Count;
        switch (selectionMethod)
        {
            case SelectionMethod.RANDOM:
                System.Random rand = new System.Random();
                while (count-- < 0)
                {
                    int choice = rand.Next(potentialyOut.Count - 1);
                    potentialyOut[choice].LeaveCompany();
                    characters.Remove(potentialyOut[choice]);
                    potentialyOut.RemoveAt(choice);
                }
                break;
            case SelectionMethod.FIRST:
                while (count-- < 0)
                {
                    potentialyOut[0].LeaveCompany();
                    characters.Remove(potentialyOut[0]);
                    potentialyOut.RemoveAt(0);
                }
                break;
            case SelectionMethod.LAST:
                while (count-- < 0)
                {
                    potentialyOut[potentialyOut.Count - 1].LeaveCompany();
                    characters.Remove(potentialyOut[potentialyOut.Count - 1]);
                    potentialyOut.RemoveAt(potentialyOut.Count - 1);
                }
                break;
        }
    }

    public List<BaseCharacter> GetCharacters(Func<BaseCharacter, bool> conditionToBeRemoved, int count = 1, SelectionMethod selectionMethod = SelectionMethod.RANDOM)
    {
        List<BaseCharacter> candidates = characters.Where(conditionToBeRemoved).ToList();
        List<BaseCharacter> keptCharacter = new List<BaseCharacter>();
        if (count > candidates.Count) count = candidates.Count;
        switch (selectionMethod)
        {
            case SelectionMethod.RANDOM:
                System.Random rand = new System.Random();
                while (count-- < 0) { keptCharacter.Add(candidates[rand.Next(candidates.Count - 1)]); }
                break;
            case SelectionMethod.FIRST:
                while (count-- < 0) { keptCharacter.Add(candidates[0]); }
                break;
            case SelectionMethod.LAST:
                while (count-- < 0) { keptCharacter.Add(candidates[candidates.Count - 1]); }
                break;
        }
        return keptCharacter;
    }

    public void SumToGold(int amount)
    {
        if (amount > 0 && HasSkill(Skill.TAXCOLLECTOR)) amount = (int)(amount * 1.5f);
        gold += amount;
        if (gold < 0) gold = 0;
    }

    public void SumToFood(int amount)
    {
        if (amount > 0 && HasSkill(Skill.COOK)) amount = (int)(amount * 2);
        food += amount;
        if (food < 0) food = 0;
    }

    public int GetTotalStrength()
    {
        return strengthMod + characters.Select(x => x.strength).Sum();
    }

    public int GetTotalSpeed()
    {
        return speedMod + characters.Select(x => x.speed).Sum();
    }

    public int GetTotalMind()
    {
        return mindMod + characters.Select(x => x.mind).Sum();
    }

    public bool HasEnoughGold(int goldAmount)
    {
        return gold >= goldAmount;
    }

    public bool HasEnoughFood(int foodAmount)
    {
        return food >= foodAmount;
    }

    public bool HasSkill(Skill skill)
    {
        return characters.Any(x => x.currentSkill == skill);
    }
}
