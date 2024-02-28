using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
  bool isPressed = false; 

  [SerializeField]
  public TMP_Text scoreText;
  public TMP_Text highScoreText;
  public static int score = 0;
  public static int highScore;
  public static int playerHealth = 3;
  public Image[] playerLives;
  public Sprite fullLives;
  public Sprite emptyLives;
  public GameObject prompt;
  public ParticleSystem explosion;

  void Update()
  {
    scoreText.SetText(score.ToString());
    highScoreText.SetText(highScore.ToString());
    PlayerHealth();

    if (score > highScore)
    {
      highScore = score;
    }

    if(Input.GetKey(KeyCode.Space) && isPressed == false)
    {
      prompt.SetActive(false);
      isPressed = true;
    }
  }

  private void PlayerHealth()
  {
    foreach (Image img in playerLives)
    {
      img.sprite = emptyLives;
    }

    for (int i = 0; i < playerHealth; i++)
    {
      playerLives[i].sprite = fullLives;
    }
  }

  public void BallDestroyed()
  {
    playerHealth--;
    StartCoroutine(Reset());
  }

  public void AsteroidDestroyed(Asteroid asteroid)
  {
    explosion.transform.position = asteroid.transform.position;
    explosion.Play();
  }

  IEnumerator Reset()
  {
    Scene currentScene = SceneManager.GetActiveScene();

    yield return new WaitUntil(() => explosion.isStopped);       
    if(playerHealth != 0)
    {
      SceneManager.LoadScene(currentScene.buildIndex);
    }
            
    else
    {
      SceneManager.LoadScene(0);
    }
  }
}
