using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{    
    [Header("Panels")]
    public GameObject _mainMenuPnl;
    public GameObject _tutorialPnl;
    public GameObject _gameOverPnl;
    
    [Header("Text Scores")]
    public TMP_Text _score;
    public TMP_Text _highScore;

    void Awake()
    {
        if(GameManager._playerHealth == 0)
        {
            GameOver();
        }

        ScoreSystem();
    }

    public void MainMenu()
    {
        ResetStats();
        _gameOverPnl.SetActive(false);
        _tutorialPnl.SetActive(false);
        _mainMenuPnl.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        _gameOverPnl.SetActive(false);
        _tutorialPnl.SetActive(true);
        _mainMenuPnl.SetActive(false);
    }

    public void GameOver()
    {
        _gameOverPnl.SetActive(true);
        _tutorialPnl.SetActive(false);
        _mainMenuPnl.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        ResetStats();
        SceneManager.LoadScene(1);
    }

    private void ResetStats()
    {
        GameManager._score = 0;
        GameManager._playerHealth = 3;
    }

    private void ScoreSystem()
    {
        _score.SetText(GameManager._score.ToString());
        _highScore.SetText(GameManager._highScore.ToString());
    }
}
