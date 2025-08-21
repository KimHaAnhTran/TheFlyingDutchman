using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float maximum;
    public float current;
    
    [SerializeField] private Image fill;
    private bool shouldFill = true;

    [Header("Spawners After Midpoint")]
    public GameObject tentacleSpawner;
    public GameObject obstacleSpawner;
    public GameObject lightningSpawner;
    public GameObject midpointCutscene;

    [Header("The End")]
    public GameObject lastCutscene;


    // Start is called before the first frame update
    private void Start()
    {
        //For debugging
        //current = 58f;
        current = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (shouldFill) 
        { 
            increaseProgress();
            getCurrentFill();
        }
        if (current >= 60f && current < 61) {
            shouldFill = false;
            tentacleSpawner.SetActive(false);
            obstacleSpawner.SetActive(false);
            lightningSpawner.SetActive(false);
            midpointCutscene.SetActive(true);
        }
        else
        {
            shouldFill = true;
        }

        if(current >= maximum)
        {
            tentacleSpawner.SetActive(false);
            obstacleSpawner.SetActive(false);
            lightningSpawner.SetActive(false);
            lastCutscene.SetActive(true);
        }
    }

    private void getCurrentFill()
    {
        float fillAmount = current / maximum;
        fill.fillAmount = fillAmount;
    }

    private void increaseProgress()
    {
        current += Time.deltaTime;
    }

    public void resumeCurrent()
    {
        current = 61;
        shouldFill = true;
    }
}
