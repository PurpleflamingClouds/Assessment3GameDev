using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class GhostTimer : MonoBehaviour
{
    public Text timerText;
    public GameObject timerUI;

    private void Start()
    {
        timerUI.SetActive(false); 
    }

    public void StartTimer()
    {
        timerUI.SetActive(true); 
        StartCoroutine(TimerCoroutine(10)); 
    }

    private IEnumerator TimerCoroutine(float duration)
    {
        float timeLeft = duration;

        while (timeLeft > 0)
        {
            timerText.text = Mathf.Ceil(timeLeft).ToString();
            timeLeft -= Time.deltaTime;
            yield return null; 
        }

        timerText.text = "0";
        timerUI.SetActive(false);
    }
}
