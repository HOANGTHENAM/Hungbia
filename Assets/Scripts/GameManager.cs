using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState currentState;
    public static event Action OnGamePlay;
    public static event Action OnGamePause;
    public static event Action OnGameOver;

    private int score = 0;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        currentState = GameState.Play;
        OnGamePlay?.Invoke();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SetPause();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SetPlay();
        }
          
    }
    public void SetPlay()
    {
        if(currentState == GameState.Play)
        {
            return;
        }
        currentState = GameState.Play;
        OnGamePlay?.Invoke();
    }
    public void SetPause()
    {
        if (currentState == GameState.Pause)
        {
            return;
        }
        currentState = GameState.Pause;
        OnGamePause?.Invoke();
    }
    public void SetGameOver()
    {
        if (currentState == GameState.GameOver)
        {
            return;
        }
        currentState = GameState.GameOver;
        OnGameOver?.Invoke();
    }
   
    public enum GameState
    {
        Play = 0,
        Pause = 1,
        GameOver = 2,
        
    }
    public void IncreaseScore(int point)
    {
        score += point;
    }
    public int SetScore()
    {
        return score;
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
