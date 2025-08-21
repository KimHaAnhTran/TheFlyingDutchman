using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [SerializeField] private GameObject cannon;
    [SerializeField] private float cannonVelocity = 2f;
    [SerializeField] private float cloneSize = 5f;
    [SerializeField] private AudioSource cannonSFX;

    private bool shouldFire = true;
    private float timerFire = 0f;
    
    // Update is called once per frame
    private void Update()
    {
        if (shouldFire) { spawnClone();}
        else
        {
            timerFire += Time.deltaTime;
            if(timerFire >= 0.5f)
            {
                shouldFire = true;
                timerFire = 0f;
            }
        }
    }

    private void spawnClone()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            cannonSFX.Play();
            GameObject cannonClone = Instantiate(cannon, transform.position, Quaternion.identity);
            cannonClone.transform.localScale = new Vector3(cloneSize, cloneSize, 0);
            cannonClone.GetComponent<Rigidbody2D>().velocity = Vector2.up * cannonVelocity;
         
            Destroy(cannonClone, 1f);
            
            shouldFire = false;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            cannonSFX.Play();
            GameObject cannonClone = Instantiate(cannon, transform.position, Quaternion.identity);
            cannonClone.transform.localScale = new Vector3(cloneSize, cloneSize, 0);
            cannonClone.GetComponent<Rigidbody2D>().velocity = Vector2.down * cannonVelocity;

            Destroy(cannonClone, 1f);
            shouldFire = false;
        }
    }

}
