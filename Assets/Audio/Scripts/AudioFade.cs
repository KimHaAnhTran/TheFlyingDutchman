using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour
{
    [SerializeField] private float musicDuration = 0.2f;
    [SerializeField] private float maxVolume = 0.3f;
    public AudioSource bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        bgMusic.volume = 0f;
        StartCoroutine(fadeInMusic());
    }

    public IEnumerator fadeInMusic()
    {
        while (bgMusic.volume <= maxVolume)
        {
            bgMusic.volume += musicDuration;
            yield return new WaitForSeconds(0.001f);
        }
    }
}
