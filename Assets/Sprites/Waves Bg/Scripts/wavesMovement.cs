using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timeCounter = 0f;
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float maxTime = 4f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocity, 0);
    }
    private void Update()
    {
        timeCounter += Time.deltaTime; 
        if (timeCounter >= maxTime)
        {
            Destroy(gameObject);
        }
    }

}
