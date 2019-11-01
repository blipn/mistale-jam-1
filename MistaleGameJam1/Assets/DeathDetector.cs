using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathDetector : MonoBehaviour
{
    public static bool isPlayerDed;

    private void Start()
    {
        isPlayerDed = false;
    }

    private void Update()
    {
        if (isPlayerDed)
        {
            if (Input.GetKey("escape"))
            {
                SceneManager.LoadScene("Menu");
            }
            if (Input.GetKey("r"))
            {
                SceneManager.LoadScene("Proto");
            }
        }
    }
}
