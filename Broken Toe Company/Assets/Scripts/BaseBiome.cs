using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BaseEncounter;
using Random = System.Random;

public class BaseBiome : MonoBehaviour
{
    public enum TypeBiome { FORET, DESERT }
    // enum TypeBiome { CLAIRIERE, CHAMP, FORET, CIMETIERE, CHATEAU, CRYPTE, FORET_NOIRE, DESERT }
    public TypeBiome currentBiome;

    public Sprite spriteBiome;
    public Image currentBiomeImage;
    Random random = new Random();

    public BaseEncounter baseEncounter;

    private void Start()
    {
        currentBiomeImage = transform.Find("biome").GetComponent<Image>();
        
    }

    public void initSprite(Sprite spriteBiomeSend)
    {
        spriteBiome = spriteBiomeSend;
        currentBiomeImage.sprite = spriteBiome;
    }

    public static BaseBiome GenerateBiome()
    {
        GameObject biomeObject = (GameObject)Instantiate(Resources.Load("BiomePrefab"));
        BaseBiome baseBiome = biomeObject.GetComponent<BaseBiome>();

        Array values = Enum.GetValues(typeof(TypeBiome));
        baseBiome.currentBiome = (TypeBiome)values.GetValue(baseBiome.random.Next(values.Length));

        baseBiome.CreateEncounter();

        return baseBiome;
    }

    public void CreateEncounter()
    {
        baseEncounter = GenerateEncounter();
        baseEncounter.transform.SetParent(transform.Find("PanelEncounter"));
    }
}
