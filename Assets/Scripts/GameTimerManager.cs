using UnityEngine;
using UnityEngine.UI;

public class GameTimerManager : MonoBehaviour
{
    public Text timerText;
    private float elapsedTime = 0f;
    private bool isTimerRunning = false;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        SaveTotalTimePlayed();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);

        timerText.text = string.Format("Game Timer: {0:D2}:{1:D2}:{2:D2}", minutes, seconds, milliseconds);
    }

    private void SaveTotalTimePlayed()
    {
        float totalTimePlayed = PlayerPrefs.GetFloat("TotalTimePlayed", 0f);
        totalTimePlayed += elapsedTime;
        PlayerPrefs.SetFloat("TotalTimePlayed", totalTimePlayed);
    }

    public float GetTotalTimePlayed()
    {
        return PlayerPrefs.GetFloat("TotalTimePlayed", 0f);
    }
}
