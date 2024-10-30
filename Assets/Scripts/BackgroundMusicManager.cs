using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public static BackgroundMusicManager Instance { get; private set; }

    public AudioSource audioSource; 
    public AudioClip normalMusic;  
    public AudioClip scaredMusic;  

    private float scaredMusicDuration = 10f; 
    private float timer = 0f; 
    private bool isScaredMusicPlaying = false; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
 
        PlayNormalMusic();
    }

    private void Update()
    {
 
        if (isScaredMusicPlaying)
        {
            timer += Time.deltaTime; 

  
            if (timer >= scaredMusicDuration)
            {
                PlayNormalMusic(); 
                isScaredMusicPlaying = false; 
                timer = 0f; 
            }
        }
    }

    public void PlayNormalMusic()
    {
        if (audioSource.clip != normalMusic)
        {
            audioSource.clip = normalMusic;
            audioSource.Play();
            isScaredMusicPlaying = false; 
            timer = 0f; 
        }
    }

    public void PlayScaredMusic()
    {
        if (audioSource.clip != scaredMusic)
        {
            audioSource.clip = scaredMusic;
            audioSource.Play();
            isScaredMusicPlaying = true; 
            timer = 0f; 
        }
    }
}
