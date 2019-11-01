using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static bool isPaused = true;
    [SerializeField] private GameObject pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = 1f;
    }
    
    void Pause() {
        isPaused = true;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        
    }
    
}
