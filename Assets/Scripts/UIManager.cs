using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public Button replayRtn;
    private void Update()
    {
        SetScoreText(GameManager.Instance.SetScore().ToString());
        
    }
    private void OnEnable()
    {
        GameManager.OnGamePlay += OffGameOverPanel;      
        GameManager.OnGameOver += ShowGameOverPanel;   
    }
    public void OnDisable()
    {
        GameManager.OnGamePlay -= OffGameOverPanel;      
        GameManager.OnGameOver -= ShowGameOverPanel;
    }
    public void SetScoreText(string text)
    {
        if(scoreText)
            scoreText.text = text;
    }
    public void ShowGameOverPanel()
    {
        if(gameOverPanel)
            gameOverPanel.SetActive(true);
    }
    public void OffGameOverPanel()
    {
        if (gameOverPanel)
            gameOverPanel.SetActive(false);
    }
    
}
