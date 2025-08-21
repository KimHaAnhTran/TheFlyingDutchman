using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//Fuel bar, introduced in the second half of the chase, helps player move faster
//However, fuel is limited
public class FuelBar : MonoBehaviour
{
    [SerializeField] private float maximum;
    public float current;
    public GameObject ironClad;
    private float currentFillAmount;

    [SerializeField] private Image fill;

    // Start is called before the first frame update
    void Start()
    {
        ironClad.GetComponent<PlayerMovement>().canShift = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            increaseProgress();
            getCurrentFill();
        }

        if (currentFillAmount >= 1)
        {
            ironClad.GetComponent<PlayerMovement>().canShift = false;
        }
                
    }

    private void getCurrentFill()
    {
        currentFillAmount = current / maximum;
        fill.fillAmount = currentFillAmount;
    }

    private void increaseProgress()
    {
        current += Time.deltaTime;
    }
}
