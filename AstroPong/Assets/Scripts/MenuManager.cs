using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _gameBtn;
    [SerializeField] private Button _retryBtn;
    [SerializeField] private Button _mainmenuBtn;
    
    public GameObject _mainMenuPnl;
    public GameObject _gameOverPnl;
    public TMP_Text _score;
    public TMP_Text _highScore;

    void Awake()
    {
        _gameBtn.onClick.AddListener(() => SceneManager.LoadScene(1));
        _retryBtn.onClick.AddListener(() => Retry());
        _mainmenuBtn.onClick.AddListener(() => MainMenuButton());

        if(GameManager._playerHealth == 0)
        {
            GameOver();
        }

        ScoreSystem();
    }

    private void MainMenuButton()
    {
        ResetStats();
        _gameOverPnl.SetActive(false);
        _mainMenuPnl.SetActive(true);
    }

    private void GameOver()
    {
        _gameOverPnl.SetActive(true);
        _mainMenuPnl.SetActive(false);
    }

    private void Retry()
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
