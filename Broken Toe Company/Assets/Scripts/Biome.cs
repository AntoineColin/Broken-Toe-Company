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
        currentBiomeImage = transform.Find("biome").GetComponent<Image>();
        PickBiome();
    }

    public void PickBiome()
    {
        //Array values = Enum.GetValues(typeof(TypeBiome));
        //Random random = new Random();
        //currentBiome = (TypeBiome)values.GetValue(random.Next(values.Length));
        UpdateImageBiome(currentBiome.ToString());
    }

    public void UpdateImageBiome(string typeBiome)
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

    public static Biome GenerateBiome()
    {
        GameObject goBiome = (GameObject)Instantiate(Resources.Load("Biome"));
        Biome biome = goBiome.GetComponent<Biome>();
        return biome;
    }
}
