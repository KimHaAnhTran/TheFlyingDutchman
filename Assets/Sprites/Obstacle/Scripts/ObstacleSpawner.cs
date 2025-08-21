using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    public float maxTime = 15f;
    [SerializeField] private float destructTime = 4f;
    [SerializeField] private float cloneSize = 5f;
    private float heightRange = 3.5f,timeCount = 0;
    private void Start()
    {
        //spawnObstacle();
    }
    private void spawnObstacle()
    {
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y + Random.Range(-heightRange,heightRange), 0);
        GameObject obstacleClone = Instantiate(obstacle, startPos, Quaternion.identity);
        obstacleClone.transform.localScale = new Vector3(cloneSize, cloneSize, 0);
        Destroy(obstacleClone, destructTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCount >= maxTime)
        {
            spawnObstacle();
            timeCount = 0;
        }
        timeCount += Time.deltaTime;
    }
}
