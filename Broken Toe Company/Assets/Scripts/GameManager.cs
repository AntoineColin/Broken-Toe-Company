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
        company = FindObjectOfType<Company>();
    }

    void Update()
    {
        ChronoUpdate();
        if (chrono >= maxChrono)
        {
            //Biome.changeEncounter();
            chrono = 0;
            maxChrono = 10;
            timerChoose.ResetSlider(maxChrono);
            biome = Biome.GenerateBiome();
            onEncounterChange.Invoke();
            UpdateAllBiome();
        }

    }

    void GenerateChoices(int choiceNumber)
    {

    }

    void ChronoUpdate()
    {
        chrono += Time.deltaTime;
        timerChoose.setSliderVal(chrono);
    }

    void UpdateAllBiome()
    {

    }
}
