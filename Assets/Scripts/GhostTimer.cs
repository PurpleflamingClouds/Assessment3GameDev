using UnityEngine;
using UnityEngine.UI;

public class GhostTimer : MonoBehaviour
{
    public Text timerText;        
    private float timeLeft = 0f;  
    private bool isTimerRunning = false; 
    private const string defaultText = "Ghost Scared Timer: 0"; 

    private void Start()
    {
        timerText.text = defaultText; 
    }

 
    public void StartTimer(float duration)
    {
        timeLeft = duration;
        isTimerRunning = true;
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
        timerText.text = defaultText; 
    }
}
