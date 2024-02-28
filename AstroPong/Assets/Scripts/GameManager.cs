using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
  bool _isPressed = false; 

  [Header("Game Settings")]
  [SerializeField]
  public TMP_Text _scoreText;
  public TMP_Text _highscoreText;
  public static int _score = 0;
  public static int _highScore;
  public static int _playerHealth = 3;
  public Image[] _playerLives;
  public Sprite _fullLives;
  public Sprite _emptyLives;
  public GameObject _prompt;
  public ParticleSystem _explosion;

  [Header("Audio")]
  [SerializeField] AudioSource _audio;
  public AudioClip _explosionSFX;

  void Update()
  {
    _scoreText.SetText(_score.ToString());
    _highscoreText.SetText(_highScore.ToString());
    PlayerHealth();

    if (_score > _highScore)
    {
      _highScore = _score;
    }

    if(Input.GetKey(KeyCode.Space) && _isPressed == false)
    {
      _prompt.SetActive(false);
      _isPressed = true;
    }
  }

  private void PlayerHealth()
  {
    foreach (Image img in _playerLives)
    {
      img.sprite = _emptyLives;
    }

    for (int i = 0; i < _playerHealth; i++)
    {
      _playerLives[i].sprite = _fullLives;
    }
  }

  public void BallDestroyed(Ball ball)
  {
    _explosion.transform.position = ball.transform.position;
    _explosion.Play();
    _playerHealth--;
    StartCoroutine(Reset());
  }

  public void AsteroidDestroyed(Asteroid asteroid)
  {
    _explosion.transform.position = asteroid.transform.position;
    _explosion.Play();
    _audio.clip = _explosionSFX;
    _audio.Play();
  }

  IEnumerator Reset()
  {
    Scene currentScene = SceneManager.GetActiveScene();

    yield return new WaitUntil(() => _explosion.isStopped);       
    if(_playerHealth != 0)
    {
      SceneManager.LoadScene(currentScene.buildIndex);
    }
            
    else
    {
      SceneManager.LoadScene(0);
    }
  }
}
