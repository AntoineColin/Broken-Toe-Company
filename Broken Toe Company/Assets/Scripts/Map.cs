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

    Random random = new Random();

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
        newBiome.initSprite(BiomeSprite[random.Next(BiomeSprite.Count)]);
        newBiome.baseEncounter.initSpriteEncounter(EncounterSprite[random.Next(EncounterSprite.Count)]);

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
        BaseBiome waitingCleanBiome = null;

        int checkSelected = -1;
        for (int i = 0; i < biomes.Count; i++)
        {
            if (i != 0 && biomes[i].selected > checkSelected)
            {
                waitingCleanBiome = biomes[i];
                checkSelected = biomes[i].selected;
            }
        }
            

        foreach (BaseBiome biome in biomes)
        {
            if (biome != waitingCleanBiome)
                Destroy(biome.gameObject);
        }
        biomes.Clear();

        biomes.Add(waitingCleanBiome);
        biomes[0].GetComponent<Button>().enabled = false;
        biomes[0].transform.SetParent(transform.Find("BiomePrincipal"));

        

        for (int i = 0; i < 3; i++)
        {
            BaseBiome newBiome = GenerateBiome();

            newBiome.initSprite(BiomeSprite[random.Next(BiomeSprite.Count)]);
            newBiome.baseEncounter.initSpriteEncounter(EncounterSprite[random.Next(EncounterSprite.Count)]);
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
