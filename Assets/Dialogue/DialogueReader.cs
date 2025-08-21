using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueReader : DialogueBaseClass
    {
        private TMP_Text textHolder;

        [Header("Text Options")]
        [SerializeField] private string[] dialogueList;

        [Header("Time Parameters")]
        [SerializeField] private float delay;
        private int i = 0;
        private string input;

        [Header("Enable objects")]
        public GameObject objectToEnable;

        [Header("Avatar Options")]
        public GameObject lieutenant;
        public GameObject captain;
        [SerializeField] private int[] avatarList;
        [SerializeField] private bool shouldAvatar = true;

        [Header("Audio Source")]
        [SerializeField] private AudioSource typeSound;

        private void Awake()
        {
            gameObject.SetActive(true);
            textHolder = GetComponent<TMP_Text>();
            StartCoroutine(startNewDialogue());
        }

        private IEnumerator startNewDialogue()
        {
            foreach (string line in dialogueList)
            {
                if (shouldAvatar)
                {
                    if (avatarList[i] == 0)
                    {
                        captain.SetActive(true);
                        lieutenant.SetActive(false);
                    }
                    else
                    {
                        captain.SetActive(false);
                        lieutenant.SetActive(true);
                    }
                }
                yield return StartCoroutine(WriteText(dialogueList[i], textHolder, delay, typeSound));
                i++;
            }
            enableObject();
            if (shouldAvatar)
            {
                captain.SetActive(false);
                lieutenant.SetActive(false);
            }
            gameObject.SetActive(false);
        }

        void enableObject()
        {
            objectToEnable.SetActive(true);
        }

        void disableObject()
        {
            objectToEnable.SetActive(false);
        }
    }
}