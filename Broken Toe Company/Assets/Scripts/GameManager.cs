using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public BaseEncounter currentEncounter;
    public float chrono = 10;
    public TimerChoose timerChoose;

    void Start()
    {
        
    }

    private void Update()
    {
        chronoUpdate();
        if (chrono == 0)
        {
            //Biome.changeEncounter();
            chrono = 5;
            timerChoose.ResetSlider(chrono);
        }
            
    }

    void GenerateChoices(int choiceNumber)
    {

    }

    void chronoUpdate()
    {
        chrono -= Time.deltaTime;
        timerChoose.setSliderVal(chrono);
    }
}
