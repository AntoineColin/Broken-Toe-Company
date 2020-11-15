using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseBiome;
using Random = System.Random;

public class Map : MonoBehaviour
{
    public List<BaseBiome> biomes;
    public Sprite foret, desert;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            BaseBiome newBiome = GenerateBiome();
            if (i == 1 || i == 3)
            {
                newBiome.initSprite(foret);
            }
            else
            {
                newBiome.initSprite(desert);
            }
            
            AddBiome(newBiome);
            if (i == 0)
            {
                newBiome.transform.SetParent(transform.Find("BiomePrincipal"));
            }
            else
            {
                newBiome.transform.SetParent(transform.Find("BiomeChoix"));
            }
        }
    }

    public void UpdateAllBiome(int choosenBiome)
    {
        BaseBiome waitingCleanBiome = biomes[choosenBiome];

        foreach (BaseBiome biome in biomes)
        {
            if (biome != waitingCleanBiome)
                Destroy(biome.gameObject);
        }
        biomes.Clear();

        biomes.Add(waitingCleanBiome);
        biomes[0].transform.SetParent(transform.Find("BiomePrincipal"));

        for (int i = 0; i < 3; i++)
        {
            BaseBiome newBiome = GenerateBiome();
            Random random = new Random();
            
            if (random.Next(1, 3) <= 2)
            {
                newBiome.initSprite(foret);
            }
            else
            {
                newBiome.initSprite(desert);
            }
            AddBiome(newBiome);
            newBiome.transform.SetParent(transform.Find("BiomeChoix"));
        }
    }

    void AddBiome(BaseBiome newBiome)
    {
        biomes.Add(newBiome);            
    }
}
