using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public Text highScoreText;
    public Text totalTimeText;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;

        float totalTimePlayed = PlayerPrefs.GetFloat("TotalTimePlayed", 0f);
        int minutes = Mathf.FloorToInt(totalTimePlayed / 60);
        int seconds = Mathf.FloorToInt(totalTimePlayed % 60);
        totalTimeText.text = string.Format("Total Time Played: {0:D2}:{1:D2}", minutes, seconds);
    }
}