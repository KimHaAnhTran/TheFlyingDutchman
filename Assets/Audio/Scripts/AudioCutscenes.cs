using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An audiopool script to storing a bunch of audio and SFX methods to be called in Timeline cutscenes
public class AudioCutscenes : MonoBehaviour
{

    [SerializeField] private float maxVolume = 0.25f, musicDuration = 0.002f;
    public AudioSource defaultMusic, introChaseMusic, chaseMusic;

    public bool skipDialogue = false;

    private void Start()
    {
        introChaseMusic.volume = 0f;
        chaseMusic.volume = 0f;
    }

    public void fadeOutDefault() {
        StartCoroutine(fadeOutMusic(defaultMusic));
    }
    /*---------------------*/
    public void fadeInIntroChase()
    {
        if(!skipDialogue) { StartCoroutine(fadeInMusic(introChaseMusic)); }
    }

    public void fadeOutIntroChase()
    {
        StartCoroutine(fadeOutMusic(introChaseMusic));
    }
    /*---------------------*/
    public void fadeInChase()
    {
        StartCoroutine(fadeInMusic(chaseMusic));
    }

    public void fadeOutChase()
    {
        StartCoroutine(fadeOutMusic(chaseMusic));
    }
    /*---------------------*/


    public IEnumerator fadeInMusic(AudioSource bgMusic)
    {
        bgMusic.Play();
        while (bgMusic.volume <= maxVolume)
        { 
            bgMusic.volume += musicDuration; 
            yield return new WaitForSeconds(0.001f);
        }
    }


    public IEnumerator fadeOutMusic(AudioSource bgMusic)
    {
        while (bgMusic.volume > 0f)
        {
            bgMusic.volume -= musicDuration;
            yield return new WaitForSeconds(0.001f);
        }
        bgMusic.Stop();

    }
}
