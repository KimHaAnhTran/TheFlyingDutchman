using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//Option to skip dialogue when player selected "Yes" option in the intro cutscene
public class SkipYesDialogue : MonoBehaviour, IPointerClickHandler
{
    public GameObject yesCutscene1;
    public GameObject yesCutscene2;
    public GameObject lieutenantAvatar;
    public GameObject captainAvatar;
    public GameObject frame;
    public AudioCutscenes frameScript;
    [SerializeField] private AudioSource clickSound;

    private void Start()
    {
        frameScript = frame.GetComponent<AudioCutscenes>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        frameScript.skipDialogue = true;
        clickSound.Play();
        yesCutscene1.SetActive(true);
        yesCutscene2.SetActive(true);
        lieutenantAvatar.SetActive(false);
        captainAvatar.SetActive(false);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

}
