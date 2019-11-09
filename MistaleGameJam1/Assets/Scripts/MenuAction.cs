using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAction : MonoBehaviour
{
    public void Play()
    {
        if (PlayerPrefs.GetInt("tutorialDone") == 0)
        {
            SceneManager.LoadScene("SceneAlex");
        }
        else
        {
            SceneManager.LoadScene("Proto");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
