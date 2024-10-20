using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for SceneManager

public class UIManager : MonoBehaviour
{

    public void LoadFirstLevel()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded; 
        SceneManager.LoadScene("MainScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    // Update is called once per frame
    void Update()
    {

    }
}
