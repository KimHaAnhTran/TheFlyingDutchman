using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using Unity.VisualScripting;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject startGame;
    [SerializeField] private float musicEndDuration = 0.2f;
    public AudioSource bgMusic;
    public AudioSource clickSound;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(fadeOutMusic());
        clickSound.Play();
        startGame.SetActive(true);
        GameObject.Find("Title Parents").transform.SetSiblingIndex(1);
        //gameObject.transform.parent.transform.SetSiblingIndex(1);
    }

    public IEnumerator fadeOutMusic()
    {  
        while (bgMusic.volume < 1f)
        {
            bgMusic.volume -= musicEndDuration;
            yield return new WaitForSeconds(0.001f);
        }
    }

}
