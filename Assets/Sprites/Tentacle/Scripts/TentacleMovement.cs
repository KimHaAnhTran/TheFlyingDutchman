using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TentacleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool attachPlayer = false;
    private GameObject ironclad;
    [SerializeField] private float speed = 3f;
    private float timer = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (transform.position.y > 0)
        {
            //transform.eulerAngles = new Vector3(0, 180, 180);
            rb.velocity = Vector2.down * speed;
        }
        else
        {
            //transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = Vector2.up * speed;
        }
        ironclad = GameObject.Find("Ironclad"); 
    }

    // Update is called once per frame
    private void Update()
    {
        if (attachPlayer)
        {
            transform.position = ironclad.transform.position;
        }
        else if(!attachPlayer)
        {
            timer += Time.deltaTime;
            if (timer > 5f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().CompareTag("Player"))
        {
            attachPlayer = true;
        }
    }

}
