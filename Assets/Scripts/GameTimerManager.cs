using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerManager : MonoBehaviour
{
    public Text timerText; // Assign the UI Text element in the Inspector
    private float elapsedTime = 0f; // Total time passed in seconds
    private bool isTimerRunning = false; // Control whether the timer is running

    private void Start()
    {
        // Start the timer
        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime; // Increment the elapsed time
            UpdateTimerText(); // Update the displayed timer text
        }
    }

    // Method to start the timer
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    // Method to stop the timer
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // Update the timer text display
    private void UpdateTimerText()
    {
        // Calculate hours, minutes, and seconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100); // Convert to milliseconds (0-99)

        // Format the time string as "00:00:00"
        timerText.text = string.Format("Gamer Timer: {0:D2}:{1:D2}:{2:D2}", minutes, seconds, milliseconds);
    }
}
