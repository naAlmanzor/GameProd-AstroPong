using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

//NOTE: System.Numerics is removed for Vector2 lines of code to function
public class GameManager : MonoBehaviour
{
  [SerializeField]
  public TMP_Text scoreText;
  public static int score = 0;
  public static int highScore;

  // //New code will be here
  // public int asteroidCount = 0;
  // private int level = 0;
  // [SerializeField] private Asteroid asteroidPrefab;

  [SerializeField]
  public static int playerHealth = 3;
  public Image[] playerLives;
  public Sprite fullLives;
  public Sprite emptyLives;

  void Update()
  {
    scoreText.SetText(score.ToString());
    PlayerHealth();

    if (score > highScore)
    {
      highScore = score;
    }

    // //Modifications will start here
    // if (asteroidCount == 0)
    // {
    //   level++;
    // }

    // int numAsteroids = 2 + (2 * level);
    // for (int i = 0; i < numAsteroids; i++)
    // {
    //   SpawnAsteroid();
    // }
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

  //spawn asteroid method will be here
  // private void SpawnAsteroid()
  // {
  //   float offset = Random.Range(0f, 1f);
  //   Vector2 viewportSpawnPosition = Vector2.zero;

  //   //Which edge
  //   int edge = Random.Range(0, 4);
  //   if (edge == 0)
  //   {
  //     viewportSpawnPosition = new Vector2(offset, 0);
  //   }
  //   else if (edge == 1)
  //   {
  //     viewportSpawnPosition = new Vector2(offset, 1);
  //   }
  //   else if (edge == 2)
  //   {
  //     viewportSpawnPosition = new Vector2(0, offset);
  //   }

  // Creates the asteroid
  // Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
  // Asteroid asteroid = Instantiate(asteroidPrefab, worldSpawnPosition, Quaternion.identity);
  // asteroid.gameManager = this;


  // }
}
