using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Company : MonoBehaviour
{
    public List<BaseCharacter> characters;

    void Start()
    {
        
    }

    void AddCharacter(BaseCharacter character)
    {
        characters.Add(character);
    }

    void RemoveCharacter()
    {
        
    }

    bool canFish()
    {
        return characters.Any(x => x.canFish == true);
    }

    bool canHunt()
    {
        return characters.Any(x => x.canHunt == true);
    }

    bool canResurrect()
    {
        return characters.Any(x => x.canResurrect == true);
    }
}
