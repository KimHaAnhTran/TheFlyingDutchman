using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tentacle;
    [SerializeField] private GameObject ironclad;
    public float maxTime = 3f;
    [SerializeField] private float cloneSize = 8f;
    private float timeCount = 0;

    private void Start()
    {
        spawnObstacle();
    }
    // Update is called once per frame
    private void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= maxTime)
        {
            spawnObstacle();
            timeCount = 0;
        }
        transform.position = new Vector3(ironclad.transform.position.x, transform.position.y, 0);
    }

    private void spawnObstacle()
    {
        float ySpawn = Random.Range(-1, 1) == -1 ? -6 : 6;
        Vector3 startPos = new Vector3(transform.position.x, ySpawn, 0);
        GameObject tentacleClone = Instantiate(tentacle, startPos, Quaternion.identity);
        tentacleClone.transform.localScale = new Vector3(cloneSize, cloneSize, 0);
    }
}
