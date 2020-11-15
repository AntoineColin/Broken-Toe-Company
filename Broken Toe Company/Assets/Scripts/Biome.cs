using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Biome : MonoBehaviour
{
    public enum TypeBiome { CLAIRIERE, CHAMP, FORET, CIMETIERE, CHATEAU, CRYPTE, FORET_NOIRE, DESERT }
    public TypeBiome currentBiome = TypeBiome.FORET;

    public BiomeImage biomeImage;

    private void Start()
    {
        biomeImage = GetComponent<BiomeImage>();
        pickBiome();
    }

    public void pickBiome()
    {
        Array values = Enum.GetValues(typeof(TypeBiome));
        Random random = new Random();
        currentBiome = (TypeBiome)values.GetValue(random.Next(values.Length));
        biomeImage.changeSpriteBiome("DESERT");
    }
}
