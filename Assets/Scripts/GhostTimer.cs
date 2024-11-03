using UnityEngine;
using UnityEngine.UI;

public class GhostTimer : MonoBehaviour
{
    public Text timerText;
    private float timeLeft = 0f;
    private bool isTimerRunning = false;


    private void Start()
    {

        timerText.enabled = false;  
    }

    public void StartTimer(float duration)
    {
        timeLeft = duration;
        isTimerRunning = true;
        timerText.enabled = true;   
        UpdateTimerText();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft > 0)
            {
                UpdateTimerText();
            }
            else
            {
                EndTimer();
            }
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = "Ghost Scared Timer: " + Mathf.Ceil(timeLeft).ToString();
    }

    private void EndTimer()
    {
        isTimerRunning = false;

        timerText.enabled = false;   
    }
}
