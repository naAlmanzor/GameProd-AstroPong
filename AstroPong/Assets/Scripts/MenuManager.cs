using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button gameBtn;
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button mainmenuBtn;
    
    public GameObject mainMenuPnl;
    public GameObject gameOverPnl;
    public TMP_Text score;
    public TMP_Text highScore;

    void Awake()
    {
        gameBtn.onClick.AddListener(() => SceneManager.LoadScene(1));
        retryBtn.onClick.AddListener(() => Retry());
        mainmenuBtn.onClick.AddListener(() => MainMenuButton());

        if(GameManager.playerHealth == 0)
        {
            GameOver();
        }

        ScoreSystem();
    }

    private void MainMenuButton()
    {
        ResetStats();
        gameOverPnl.SetActive(false);
        mainMenuPnl.SetActive(true);
    }

    private void GameOver()
    {
        gameOverPnl.SetActive(true);
        mainMenuPnl.SetActive(false);
    }

    private void Retry()
    {
        ResetStats();
        SceneManager.LoadScene(1);
    }

    private void ResetStats()
    {
        GameManager.score = 0;
        GameManager.playerHealth = 3;
    }

    private void ScoreSystem()
    {
        score.SetText(GameManager.score.ToString());
        highScore.SetText(GameManager.highScore.ToString());
    }
}
