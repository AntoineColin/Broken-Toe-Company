using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiomeImage : MonoBehaviour
{
    public Image biomeImage;
    public Sprite foret;
    public Sprite desert;

    private void Start()
    {
        biomeImage = GetComponent<Image>();
    }

    public void changeSpriteBiome(string typeBiome)
    {
        switch (typeBiome)
        {
            case "FORET":
                biomeImage.sprite = foret;
                break;
            case "DESERT":
                biomeImage.sprite = desert;
                break;
        }
    }
}
