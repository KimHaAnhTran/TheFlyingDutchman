using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    [SerializeField] private AudioSource lightningSFX;

    //When a lightning object is instantiated, make it loud and then disappears
    private void Start()
    {
        lightningSFX.Play();
    }
    private void selfDestruct()
    {
        Destroy(gameObject);
    }
}
