using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class BaseBiome : MonoBehaviour
{
    
    public enum TypeBiome { FORET, DESERT }
    // enum TypeBiome { CLAIRIERE, CHAMP, FORET, CIMETIERE, CHATEAU, CRYPTE, FORET_NOIRE, DESERT }
    public TypeBiome currentBiome = TypeBiome.FORET;
    
    public Sprite spriteBiome;
    public Image currentBiomeImage;

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
        Random random = new Random();
        baseBiome.currentBiome = (TypeBiome)values.GetValue(random.Next(values.Length));

        return baseBiome;
    }
}
