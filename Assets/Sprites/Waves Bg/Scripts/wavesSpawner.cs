using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject waves;
    [SerializeField] private float maxTime = 4f;
    [SerializeField] private float destructTime = 8f;
    [SerializeField] private float velocity = 5f;
    private float timeCount = 0;
    private void Start()
    {
        spawnObstacle();
    }
    private void spawnObstacle()
    {
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject wavesClone = Instantiate(waves, startPos, Quaternion.identity);
        wavesClone.transform.localScale = new Vector3(11.3f, 11.3f, 11.3f);
        wavesClone.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocity;
        Destroy(wavesClone, destructTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCount >= maxTime)
        {
            spawnObstacle();
            timeCount = 0;
        }
        timeCount += Time.deltaTime;
    }

}
