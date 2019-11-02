﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static bool isPaused = true;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject playItem;
    [SerializeField] private GameObject menuInGame;
    [SerializeField] private GameObject resumeItem;
    [SerializeField] private GameObject resetItem;
    [SerializeField] private GameObject gameOverLogo;
    private string lastLevel = "Proto"; // TODO: LEVEL 1
    private bool inGame = false;
    private bool gameOver = false;
    
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

    void Resume() // TODO: sauf si gameover
    {
        isPaused = false;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = 1f;
    }
    
    void Pause() {
        isPaused = true;
        if (gameOver)
        {
            // TODO: modifier menu
        }
        pauseMenu.SetActive(isPaused);
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        // TODO: Fade
        SetupGameOver(true);
        Pause();
    }

    private void SetupGameOver(bool show)
    {
        if (show)
        {
            gameOver = true;
            resumeItem.SetActive(false);
            resetItem.SetActive(true);
            gameOverLogo.SetActive(true);
            resetItem.GetComponent<Button>().Select();
        }
        else
        {
            gameOver = false;
            resumeItem.SetActive(true);
            resetItem.SetActive(false);
            gameOverLogo.SetActive(false);
        }
    }

    private void ReloadScene()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NewGame()
    {
        ToLevel(lastLevel);
        switchInGame(true);
    }
    
    private void switchInGame(bool value)
    {
        inGame = value;
        if (inGame)
        {
            menu.SetActive(false);
            menuInGame.SetActive(true);
            resumeItem.GetComponent<Button>().Select();
        }
        else
        {
            menuInGame.SetActive(false);
            menu.SetActive(true);
            playItem.GetComponent<Button>().Select();
        }
    }
    
    private void ToLevel(string sceneName)
    {
        if (!inGame)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            Resume();
        }
        else
        {
            ReloadScene();
        }
    }

    private IEnumerator selector(Action method)
    {
        yield return new WaitForSeconds(0f); // TODO: mettre 0.1f ?
        method.Invoke();
    }

    public void button_Play()
    {
        StartCoroutine(selector(NewGame));
    }
    
    public void button_Resume()
    {
        Resume();
    }
    
    public void button_Reset()
    {
        StartCoroutine(selector(GameOver));
    }
    
    public void button_Exit()
    {
        ExitTheGame();
    }    
    
    public void button_Replay()
    {
        SetupGameOver(false);
        ReloadScene();
    }

    private void ExitTheGame()
    {
        Application.Quit();
    }
    
    public void select_Resume()
    {
        resumeItem.GetComponent<Button>().Select();
    }    
    
    public void select_Play()
    {
        playItem.GetComponent<Button>().Select();
    }
    
}
