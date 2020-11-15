using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseBiome;

public class Map : MonoBehaviour
{
    public List<BaseBiome> biomes;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            BaseBiome newBiome = GenerateBiome();
            AddBiome(newBiome);
        }
        PickBiome();
    }

    public void PickBiome()
    {
        //Array values = Enum.GetValues(typeof(TypeBiome));
        //Random random = new Random();
        //currentBiome = (TypeBiome)values.GetValue(random.Next(values.Length));
    }

    public void UpdateAllBiome(int choosenBiome)
    {
        biomes[0] = biomes[choosenBiome];
        biomes.RemoveAt(1);
        biomes.RemoveAt(2);
        biomes.RemoveAt(3);

        for (int i = 0; i < 3; i++)
        {
            BaseBiome newBiome = GenerateBiome();
            AddBiome(newBiome);
        }
        
    }

    void AddBiome(BaseBiome newBiome)
    {
        newBiome.transform.SetParent(transform);
        biomes.Add(newBiome);
    }
}
