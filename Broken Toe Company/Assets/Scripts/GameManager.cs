using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public BaseEncounter currentEncounter;
    public float chrono;
    public float maxChrono;
    public TimerChoose timerChoose;

    void Start()
    {
        timerChoose.ResetSlider(maxChrono);
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
}
