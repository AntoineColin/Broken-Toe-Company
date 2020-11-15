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

    public UnityEvent onEncounterChanged;
    public UnityEvent onResourceChanged;

    public int clickedBiome = 2;

    void Start()
    {
        onEncounterChanged = new UnityEvent();
        onResourceChanged = new UnityEvent();
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
            maxChrono = 5;
            timerChoose.ResetSlider(maxChrono);
            
            onEncounterChanged.Invoke();

            map.UpdateAllBiome(clickedBiome);
            onEncounterChanged.Invoke();
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
