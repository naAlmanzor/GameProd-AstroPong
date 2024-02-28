using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
  bool isPressed = false; 

  [SerializeField]
  public TMP_Text scoreText;
  public static int score = 0;
  public static int highScore;
  public static int playerHealth = 3;
  public Image[] playerLives;
  public Sprite fullLives;
  public Sprite emptyLives;
  public GameObject prompt;

  void Update()
  {
    scoreText.SetText(score.ToString());
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
}
