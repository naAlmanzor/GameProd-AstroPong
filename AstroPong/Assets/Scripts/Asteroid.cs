using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//NOTE: System.Numerics is removed for Vector2 lines of code to function
public class Asteroid : MonoBehaviour
{
  //Set starting asteroid _size
  public float _size;
  public float _speed;
  public float _minSize;
  public float _maxSize;
  public float _maxLifeTime;

  [SerializeField] Sprite[] _asteroidSprites;
  public SpriteRenderer _asteroidSprite;
  private Rigidbody2D _rb;

  void Awake()
  {
    _asteroidSprite = GetComponent<SpriteRenderer>(); 
    _rb = GetComponent<Rigidbody2D>();
  }

  void Start()
  { 
    _asteroidSprite.sprite = _asteroidSprites[Random.Range(0,_asteroidSprites.Length)];
    // asteroidPolygon = asteroids[randomIndex].GetComponent<PolygonCollider2D>();
    this.transform.eulerAngles = new Vector3(0, 0, Random.value * 360f);
    this.transform.localScale = Vector3.one * this._size;

    _rb.mass = this._size;
  }

  public void SetTrajectory(Vector2 direction)
  {
    _rb.AddForce(direction*this._speed);

    Destroy(this.gameObject, this._maxLifeTime);
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
