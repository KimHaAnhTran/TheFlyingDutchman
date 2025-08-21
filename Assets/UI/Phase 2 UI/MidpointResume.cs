using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Half-way through the chase, there's a brief cutscene, then introduce fuel tank bar
public class MidpointResume : MonoBehaviour
{
    public GameObject tentacleSpawner;
    public GameObject obstacleSpawner;
    public GameObject lightningSpawner;
    public GameObject progressBar;
    public GameObject fuelBar;

    private void Start()
    {
        tentacleSpawner.SetActive(true);
        obstacleSpawner.SetActive(true);
        lightningSpawner.SetActive(true);
        fuelBar.SetActive(true);

        //Set difficulty to obstacles higher
        lightningSpawner.GetComponent<LightningSpawner>().maxTime = 4.75f;
        tentacleSpawner.GetComponent<TentacleSpawner>().maxTime = 1.5f;
        obstacleSpawner.GetComponent<obstacleSpawner>().maxTime = 1.0f;
        progressBar.GetComponent<ProgressBar>().current = 61f;
    }
}
