using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class BaseEncounter : MonoBehaviour
{
    public enum TypeEncounter { FEU_DE_CAMP, LOUP, OASIS, VILLAGE }
    public TypeEncounter currentEncounter;

    public Image currentEncouterImage;
    public Sprite spriteEncounter;
    Random random = new Random();

    private void Start()
    {
        currentEncouterImage = GetComponent<Image>();
    }

    public void initSpriteEncounter(Sprite spriteEncounterSend)
    {
        spriteEncounter = spriteEncounterSend;
        currentEncouterImage.sprite = spriteEncounter;
    }

    public static BaseEncounter GenerateEncounter()
    {
        GameObject encounterObject = (GameObject)Instantiate(Resources.Load("EncounterPrefab"));
        BaseEncounter baseEncounter = encounterObject.GetComponent<BaseEncounter>();

        Array values = Enum.GetValues(typeof(TypeEncounter));
        
        baseEncounter.currentEncounter = (TypeEncounter)values.GetValue(baseEncounter.random.Next(values.Length));

        return baseEncounter;
    }

    public void ApplyEffect()
    {
        switch (currentEncounter)
        {
            case TypeEncounter.FEU_DE_CAMP:
                break;

            case TypeEncounter.LOUP:
                break;

            case TypeEncounter.OASIS:
                break;

            case TypeEncounter.VILLAGE:
                break;

        }
    }

}
