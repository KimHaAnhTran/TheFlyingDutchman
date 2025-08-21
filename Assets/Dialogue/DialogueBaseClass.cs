using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        protected IEnumerator WriteText(string input, TMP_Text textHolder, float delay, AudioSource typeSound)
        {
            textHolder.text = "";
            for (int i= 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                typeSound.Play();
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitUntil(() => Input.GetMouseButton(0));
        }


    }
}