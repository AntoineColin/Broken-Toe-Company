using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEncounter : MonoBehaviour
{
    public enum TypeEncounter { FEU_DE_CAMP, LOUP, OASIS, VILLAGE }
    public TypeEncounter currentEncounter = TypeEncounter.VILLAGE;

    public Image currentEncouterImage;
    public Sprite spriteEncounter;

    private void Start()
    {
        currentEncouterImage = transform.Find("biome").GetComponent<Image>();
    }
    void SelectAnEncounter()
    {

    }

    public void initEncounter(Sprite spriteEncounterSend)
    {
        spriteEncounter = spriteEncounterSend;
        currentEncouterImage.sprite = spriteEncounter;
    }

    public static BaseEncounter GenerateEncounter()
    {
        GameObject encounterObject = (GameObject)Instantiate(Resources.Load("EncounterPrefab"));
        BaseEncounter baseEncounter = encounterObject.GetComponent<BaseEncounter>();

        return baseEncounter;
    }

}
