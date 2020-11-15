using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    public BaseEncounter currentEncounter;
    public float chrono;
    public float maxChrono;
    public TimerChoose timerChoose;
    public Biome biome;
    public Company company;

    public UnityEvent onEncounterChange;

    void Start()
    {
        if (INSTANCE == null) INSTANCE = this;
        else Destroy(gameObject);
        timerChoose.ResetSlider(maxChrono);
<<<<<<< Updated upstream
        company = FindObjectOfType<Company>();
        biome = new Biome();
=======
>>>>>>> Stashed changes
    }

    void Update()
    {
        chronoUpdate();
        if (chrono >= maxChrono)
        {
            //Biome.changeEncounter();
            chrono = 0;
            maxChrono = 10;
            timerChoose.ResetSlider(maxChrono);
<<<<<<< Updated upstream
            biome.pickBiome();
            onEncounterChange.Invoke();
=======
            updateAllBiome();
>>>>>>> Stashed changes
        }
            
    }

    void GenerateChoices(int choiceNumber)
    {

    }

    void chronoUpdate()
    {
        chrono += Time.deltaTime;
        timerChoose.setSliderVal(chrono);
    }

    void updateAllBiome()
    {

    }
}
