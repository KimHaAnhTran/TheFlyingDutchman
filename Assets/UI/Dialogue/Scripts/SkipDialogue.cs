using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkipDialogue : MonoBehaviour, IPointerClickHandler
{

    public GameObject choicesDialogue;
    public GameObject cutscene1;
    public GameObject cutscene2;
    public GameObject lieutenantAvatar;
    public GameObject captainAvatar;

    [SerializeField] private AudioSource clickSound;
    public void OnPointerClick(PointerEventData eventData)
    {
        clickSound.Play();
        choicesDialogue.SetActive(true);
        cutscene1.SetActive(false);
        lieutenantAvatar.SetActive(false);
        captainAvatar.SetActive(false);
        cutscene2.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

}
