using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Actually spawns warning signs before spawning lightning strikes
//Sort of like Undertale's warning cues 
public class LightningSpawner : MonoBehaviour
{
    [SerializeField] private GameObject lightning;
    public float maxTime = 15f;

    private float heightRange = 4.3f, timeCount = 0;
    private void Start()
    {
        //spawnObstacle();
    }

    //Instantiate warning signs (aka dark electric waters) to show that lightning is about to strike that area
    private void spawnLightning()
    {
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y + Random.Range(-heightRange, heightRange), 0);
        GameObject obstacleClone = Instantiate(lightning, startPos, Quaternion.identity);
    }

    void Update()
    {
        if (timeCount >= maxTime)
        {
            spawnLightning();
            timeCount = 0;
        }
        timeCount += Time.deltaTime;
    }
}
