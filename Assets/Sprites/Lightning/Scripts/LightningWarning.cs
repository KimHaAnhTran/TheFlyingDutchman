using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningWarning : MonoBehaviour
{
    private float timer = 0f, strikeTimer = 0f, xStartPos = -8f;
    private Animator anim;
    public GameObject strike;

    private Camera cam;
    public float shakeStrength = 0.75f, maxShakeDuration = 0.3f, strikeTimeBetweenMax = 0.3f, timeUntilNoMoreStrike = 4f;
    private bool shouldSpawnStrike = true;
    //[SerializeField] private AudioSource lightningSFX;

    private void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.SetActive(true);
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // After an initial 2-second delay, begin the strike sequence
        if (timer >= 2f)
        {
            // Manage the rate of lightning strikes
            strikeTimer += Time.deltaTime;
            if (strikeTimer >= strikeTimeBetweenMax)
            {
                spawnStrike();
                strikeTimer = 0f;
            }

            // Apply a continuous camera shake effect during the striking sequence
            cameraShake();
        }

        // Check if the total duration has been reached to end the sequence
        if (timer >= timeUntilNoMoreStrike)
        {
            // Stop spawning new strikes
            // Reset the camera rotation to stop the shake
            shouldSpawnStrike = false;
            cam.transform.localEulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("exit", true);
        }


    }

    private void selfDestruct()
    {

        Destroy(gameObject);
    }

    // Instantiates a single lightning strike and moves the spawn position for the next one
    private void spawnStrike()
    {
        if (shouldSpawnStrike)
        {
            // Calculate the spawn position at the current Y and the progressing X
            Vector2 startPos = new Vector2(xStartPos, transform.position.y);
            GameObject clonseStrike = Instantiate(strike, startPos, Quaternion.identity);
            // Increment the X position for the next strike
            xStartPos += 2.5f;
        }
        
    }

    // Applies a random, small rotation to the camera to create a shake effect
    private void cameraShake()
    {
        float randomX = Random.value - 0.5f;
        float randomY = Random.value - 0.5f;

        cam.transform.localEulerAngles = new Vector3(randomX, randomY, 0) * shakeStrength;
    }

}
