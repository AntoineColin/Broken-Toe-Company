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
    
    public Sprite clairiere, champ, foret, cimetiere, chateau, crypte, foret_noire, desert;
    public Image currentBiomeImage;

    private void Start()
    {
        currentBiomeImage = transform.Find("biome").GetComponent<Image>();
        pickBiome();
        currentBiomeImage.sprite = foret;
    }

    public void pickBiome()
    {
        //Array values = Enum.GetValues(typeof(TypeBiome));
        //Random random = new Random();
        //currentBiome = (TypeBiome)values.GetValue(random.Next(values.Length));
        //updateImageBiome(currentBiome);
    }

    public Sprite updateImageBiome()
    {
        if (currentBiome == TypeBiome.FORET)
            return foret;

        if (currentBiome == TypeBiome.DESERT)
            return desert;

        return foret;

    }

    public static GameObject GenerateBiome()
    {
        GameObject biomeObject = (GameObject)Instantiate(Resources.Load("BiomePrefab"));
        BaseBiome baseBiome = biomeObject.GetComponent<BaseBiome>();
        return biomeObject;
    }
}
