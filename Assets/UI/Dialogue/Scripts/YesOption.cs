using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Text visual interactivity cue when player hovers mouse over "Yes" selection in the intro cutscene
public class YesOption : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool isYesOption = true;
    [SerializeField] private AudioSource clickSound;
    public GameObject yesCutscene;
    public GameObject introSkipDialogue;
    public GameObject skipDialogue;
    public GameObject noCutscene;

    public void Start()
    {
        introSkipDialogue.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isYesOption)
        {
            yesCutscene.SetActive(true);
            skipDialogue.SetActive(true);
        }
        else
        {
            noCutscene.SetActive(true);
        }
        clickSound.Play();
        gameObject.transform.parent.gameObject.SetActive(false);
    }

}
