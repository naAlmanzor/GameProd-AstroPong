using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//NOTE: System.Numerics is removed for Vector2 lines of code to function
public class Asteroid : MonoBehaviour
{
  //Set starting asteroid size
  public float size;
  public float speed;
  public float minSize;
  public float maxSize;
  public float maxLifeTime;

  [SerializeField] Sprite[] asteroidSprites;
  public SpriteRenderer asteroidSprite;
  private Rigidbody2D rb;

  void Awake()
  {
    asteroidSprite = GetComponent<SpriteRenderer>(); 
    rb = GetComponent<Rigidbody2D>();
  }

  void Start()
  { 
    asteroidSprite.sprite = asteroidSprites[Random.Range(0,asteroidSprites.Length)];
    // asteroidPolygon = asteroids[randomIndex].GetComponent<PolygonCollider2D>();
    this.transform.eulerAngles = new Vector3(0, 0, Random.value * 360f);
    this.transform.localScale = Vector3.one * this.size;

    rb.mass = this.size;
  }

  public void SetTrajectory(Vector2 direction)
  {
    rb.AddForce(direction*this.speed);

    Destroy(this.gameObject, this.maxLifeTime);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.CompareTag("Paddle"))
    {
      FindAnyObjectByType<GameManager>().AsteroidDestroyed(this);
      Destroy(this.gameObject);
    }

    if(collision.gameObject.CompareTag("Ball"))
    {
      FindAnyObjectByType<GameManager>().AsteroidDestroyed(this);
      Destroy(this.gameObject);
    }
  }

}
