using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Biome : MonoBehaviour
{
    public enum TypeBiome { CLAIRIERE, VILLAGE, CHAMP, FORET, CIMETIERE, CHATEAU, CRYPTE, FORET_NOIRE, DESERT }
    public TypeBiome currentBiome = TypeBiome.CLAIRIERE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pickBiome()
    {
        Array values = Enum.GetValues(typeof(TypeBiome));
        Random random = new Random();
        currentBiome = (TypeBiome)values.GetValue(random.Next(values.Length));
    }


}
