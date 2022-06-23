using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] TextMeshProUGUI timerText;
    float currentLvlTimer;
    float timerIncrement;
    float previousLvlTimer;
    public static int currentLvl;

    void Start()
    {
        currentLvlTimer = 20f;
        previousLvlTimer = 20f;
        timerIncrement = 10f;
        currentLvl = 1;
    }

    void Update()
    {
        currentLvlTimer -= Time.deltaTime;
        if (currentLvlTimer <= 0)
        {
            currentLvlTimer += previousLvlTimer + timerIncrement;
            timerIncrement += 5;
            previousLvlTimer = currentLvlTimer;
            currentLvl++;
        }

        waveText.text = "Wave: " + currentLvl;
        timerText.text = "Next wave in " + System.Math.Round(currentLvlTimer, 0);
    }
}
