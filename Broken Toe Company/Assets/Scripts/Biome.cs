using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Biome : MonoBehaviour
{
    public enum TypeBiome { CLAIRIERE, CHAMP, FORET, CIMETIERE, CHATEAU, CRYPTE, FORET_NOIRE, DESERT }
    public TypeBiome currentBiome = TypeBiome.FORET;
    
    public Sprite clairiere, champ, foret, cimetiere, chateau, crypte, foret_noire, desert;
    public Image currentBiomeImage;

    private void Start()
    {
        currentBiomeImage = transform.Find("biome").GetComponent<Image>();
        pickBiome();
    }

    public void pickBiome()
    {
        //Array values = Enum.GetValues(typeof(TypeBiome));
        //Random random = new Random();
        //currentBiome = (TypeBiome)values.GetValue(random.Next(values.Length));
        updateImageBiome(currentBiome.ToString());
    }

    public void updateImageBiome(string typeBiome)
    {
        switch (typeBiome)
        {
            case "FORET":
                currentBiomeImage.sprite = foret;
                break;
            case "DESERT":
                currentBiomeImage.sprite = desert;
                break;
        }
        
    }
}
