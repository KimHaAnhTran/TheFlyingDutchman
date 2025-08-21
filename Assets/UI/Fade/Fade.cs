using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void trueEnding()
    {
        SceneManager.LoadScene("4_True End");
    }

    private void badEnding()
    {
        SceneManager.LoadScene("3_Bad End");
    }

    private void escapeEnding()
    {
        SceneManager.LoadScene("2_Escape End");
    }

    public void returnHome()
    {
        SceneManager.LoadScene("0_Title Screen");
    }

    private void disableFade()
    {
        gameObject.SetActive(false);
    }
    
    private void enableFade() {
        gameObject.SetActive(true);
    }
}
