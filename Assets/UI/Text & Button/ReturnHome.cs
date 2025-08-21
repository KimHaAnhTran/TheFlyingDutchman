using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnHome : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("0_Title Screen");
    }
}
