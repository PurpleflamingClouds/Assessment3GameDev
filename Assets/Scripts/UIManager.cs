using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    public void LoadFirstLevel()
    {
        // Don't destroy this object when loading new scenes
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("MainScene");
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "MainScene")
        {

            GameObject quitButtonObject = GameObject.FindGameObjectWithTag("Quit");
            if (quitButtonObject != null)
            {

                Button quitButton = quitButtonObject.GetComponent<Button>();
                if (quitButton != null)
                {
                    quitButton.onClick.AddListener(QuitToStartScene);
                    SceneManager.sceneLoaded -= OnSceneLoaded;
                }
            }
        }

    }


    public void QuitToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
