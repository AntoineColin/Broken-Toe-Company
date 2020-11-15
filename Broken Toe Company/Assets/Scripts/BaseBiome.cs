using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class BaseBiome : MonoBehaviour
{
    public enum TypeBiome { CLAIRIERE, CHAMP, FORET, CIMETIERE, CHATEAU, CRYPTE, FORET_NOIRE, DESERT }
    public TypeBiome currentBiome = TypeBiome.FORET;
    
    public string pathSprite;
    public Image currentBiomeImage;

    private void Start()
    {
        currentBiomeImage = transform.Find("biome").GetComponent<Image>();
        pickBiome();
        //currentBiomeImage.sprite = Resources.Load<Sprite>(pathSprite);
    }

    public void pickBiome()
    {
        //Array values = Enum.GetValues(typeof(TypeBiome));
        //Random random = new Random();
        //currentBiome = (TypeBiome)values.GetValue(random.Next(values.Length));
    }

    public static BaseBiome GenerateBiome()
    {
        GameObject biomeObject = (GameObject)Instantiate(Resources.Load("BiomePrefab"));
        BaseBiome baseBiome = biomeObject.GetComponent<BaseBiome>();
        baseBiome.currentBiome = TypeBiome.FORET;
        switch (baseBiome.currentBiome)
        {
            case TypeBiome.FORET:
                baseBiome.pathSprite = "biomes/FORET";
                break;
            case TypeBiome.DESERT:
                baseBiome.pathSprite = "biomes/Desert";
                break;
        }
        return baseBiome;
    }
}
