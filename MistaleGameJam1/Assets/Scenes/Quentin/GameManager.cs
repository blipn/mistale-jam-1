using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static bool isPaused = true;
    [SerializeField] private GameObject pauseMenu;
    private string lastLevel = "SceneAlex"; // TODO: LEVEL 1
    
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
        // TODO: Fade
        ReloadScene();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    private void NewGame()
    {
        ToLevel(lastLevel);
    }
    
    private void ToLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        Resume();
    }
    
    public IEnumerator selector(Action method)
    {
        yield return new WaitForSeconds(0.1f);
        method.Invoke();
    }

    public void button_Play()
    {
        StartCoroutine(selector(NewGame));
    }
    
    public void button_Reset()
    {
        StartCoroutine(selector(ReloadScene));
    }

}
