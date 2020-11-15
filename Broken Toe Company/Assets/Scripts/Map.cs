using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BaseBiome;
using Random = System.Random;

public class Map : MonoBehaviour
{
    public List<BaseBiome> biomes;
    public List<Sprite> BiomeSprite;
    public List<Sprite> EncounterSprite;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            CreateBiome(i);
        }
    }

    public void CreateBiome(int i)
    {
        BaseBiome newBiome = GenerateBiome();
        if (i == 1 || i == 3)
        {
            newBiome.initSprite(BiomeSprite[0]);
        }
        else
        {
            newBiome.initSprite(BiomeSprite[1]);
        }

        AddBiome(newBiome);
        if (i == 0)
        {
            newBiome.transform.SetParent(transform.Find("BiomePrincipal"));
            newBiome.GetComponent<Button>().enabled = false;
        }
        else
        {
            newBiome.transform.SetParent(transform.Find("BiomeChoix"));
        }
    }

    public void UpdateAllBiome()
    {
        int index = 0;
        BaseBiome waitingCleanBiome = null;
        foreach (BaseBiome biome in biomes)
        {
                if (biome.GetComponent<Button>().isActiveAndEnabled == true)
                    waitingCleanBiome = biome;
            index++;
        }

        if (waitingCleanBiome == null)
            waitingCleanBiome = biomes[1];

        foreach (BaseBiome biome in biomes)
        {
            if (biome != waitingCleanBiome)
                Destroy(biome.gameObject);
        }
        biomes.Clear();

        biomes.Add(waitingCleanBiome);
        biomes[0].GetComponent<Button>().enabled = false;
        biomes[0].transform.SetParent(transform.Find("BiomePrincipal"));

        Random random = new Random();

        for (int i = 0; i < 3; i++)
        {
            BaseBiome newBiome = GenerateBiome();

            float rdn = random.Next(0, 2);
            if (rdn >= 1)
            {
                newBiome.initSprite(BiomeSprite[0]);
            }
            else
            {
                newBiome.initSprite(BiomeSprite[1]);
            }
            AddBiome(newBiome);
            newBiome.transform.SetParent(transform.Find("BiomeChoix"));
        }
    }

    void AddBiome(BaseBiome newBiome)
    {
        biomes.Add(newBiome);            
    }

    public void UpdateEncounter()
    {

    }
}
