using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    public BaseEncounter currentEncounter;
    public float chrono;
    public float maxChrono;
    public TimerChoose timerChoose;
    public Map map;
    public Company company;

    public UnityEvent onEncounterChange;

    public int clickedBiome = 2;

    void Start()
    {
        if (INSTANCE == null) INSTANCE = this;
        else Destroy(gameObject);
        timerChoose.ResetSlider(maxChrono);
        company = FindObjectOfType<Company>();
        map = FindObjectOfType<Map>();
    }

    void Update()
    {
        ChronoUpdate();
        if (chrono >= maxChrono)
        {
            chrono = 0;
            maxChrono = 2;
            timerChoose.ResetSlider(maxChrono);
            
            onEncounterChange.Invoke();

            map.UpdateAllBiome(clickedBiome);
            onEncounterChange.Invoke();
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
}
