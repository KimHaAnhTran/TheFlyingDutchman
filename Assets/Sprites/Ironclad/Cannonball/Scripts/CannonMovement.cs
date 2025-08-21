using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GameObject().CompareTag("tentacle"))
        {
            rb.velocity = Vector2.zero;
            Destroy(collision.gameObject);
            anim.SetBool("deathAnim", true);
        }
    }

    private void selfDestruct()
    {
        Destroy(gameObject);
    }
}
