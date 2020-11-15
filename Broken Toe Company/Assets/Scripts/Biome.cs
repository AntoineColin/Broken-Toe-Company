using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseBiome;

public class Biome : MonoBehaviour
{
    public List<BaseCharacter> biomes;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject newBiome = GenerateBiome();
            newBiome.transform.SetParent(transform);
            AddBiome(newBiome.GetComponent<BaseCharacter>());
        }
    }

    public void AddBiome(BaseCharacter character)
    {
        biomes.Add(character);
    }

    public void updateAllBiome(int choosenBiome)
    {
        biomes[0] = biomes[choosenBiome];
        biomes.RemoveAt(1);
        biomes.RemoveAt(2);
        biomes.RemoveAt(3);

        for (int i = 0; i < 3; i++)
        {
            GameObject newBiome = GenerateBiome();
            newBiome.transform.SetParent(transform);
            AddBiome(newBiome.GetComponent<BaseCharacter>());
        }
    }
}
