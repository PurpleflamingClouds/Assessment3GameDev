using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagment : MonoBehaviour
{
    public AudioSource normalStateBackground;
    public AudioSource introBackground;

    // Start is called before the first frame update
    void Start()
    {

        normalStateBackground.Stop();
        introBackground.Play();


        Invoke("PlayNormalStateBackground", 10f);
    }


    void PlayNormalStateBackground()
    {

        introBackground.Stop();


        normalStateBackground.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
