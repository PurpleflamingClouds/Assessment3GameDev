using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManager : MonoBehaviour
{
    public Image[] lives; 
    private int currentLives;

    private void Start()
    {
        currentLives = lives.Length; 
        UpdateLivesUI();
    }


    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--; 
            UpdateLivesUI();
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].gameObject.SetActive(i < currentLives); 
        }
    }
}
