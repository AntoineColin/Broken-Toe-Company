using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    public Sprite[] faces;
    public AudioClip[] clips;
    new AudioSource audio;
    bool strongerMusic = false;

    System.Random random = new System.Random();

    void Start()
    {
        onEncounterChanged = new UnityEvent();
        onResourceChanged = new UnityEvent();
        if (INSTANCE == null) INSTANCE = this;
        else Destroy(gameObject);
        timerChoose.ResetSlider(maxChrono);
        company = FindObjectOfType<Company>();
        map = FindObjectOfType<Map>();
        audio = GetComponent<AudioSource>();
        audio.clip = clips[0];
        audio.Play();
    }

    void Update()
    {
        ChronoUpdate();
        if (chrono >= maxChrono)
        {
            chrono = 0;
            timerChoose.ResetSlider(maxChrono);

            if (random.Next(5) == 4) strongerMusic = true;
            if (strongerMusic) audio.clip = clips[random.Next(2, 4)];
            else audio.clip = clips[random.Next(0, 2)];
            audio.Play();

            map.UpdateAllBiome();
            map.UpdateEncounter();
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

    public void ExitGame()
    {
        Debug.Log("exit game");
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
