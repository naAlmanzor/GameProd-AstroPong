using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D _rb;
    float _speed = 2f;
    bool _isBoostingComplete = false;

    [SerializeField] SpriteRenderer _circleSprite;
    
    [Header("Audio")]
    [SerializeField] AudioSource _audio;
    public AudioClip _paddleHit;
    public AudioClip _every5Score;
    public AudioClip _ballDestroyedSFX;

    // Start is called before the first frame update
    void Start()
    {
        //Starting velocity for Ball
        _rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        _circleSprite = GetComponentInChildren<SpriteRenderer>();

        _rb.velocity = Vector2.zero;
        StartCoroutine(WaitToStart());
    }

    void Update()
    {
        // Increases speed every 5 points if _score is greater than 0, 
        // checks if speed is more than 20
        if(GameManager._score % 5 == 0 && GameManager._score > 0 && _speed < 20f && _isBoostingComplete == false)
        {   
            if(this.gameObject.transform.position.y < 0)
            {
                // _rb.AddForce(Vector2.up * 1, ForceMode2D.Impulse);
                _rb.velocity += new Vector2(0, _speed);
            }

            if(this.gameObject.transform.position.y > 0)
            {
                // _rb.AddForce(Vector2.down * 1, ForceMode2D.Impulse);
                _rb.velocity += new Vector2(0, -_speed);
            }
            _isBoostingComplete = true;
            StartCoroutine(SpeedIncrease());
        }
    }

    IEnumerator ObjDestroyed()
    {

        _rb.velocity = new Vector2(0,0);
        _circleSprite.sprite = null;
        
        _audio.clip = _ballDestroyedSFX;
        _audio.Play(0);
        Debug.Log(_audio.clip);
        
        FindAnyObjectByType<GameManager>().BallDestroyed(this);
        Destroy(this.gameObject, 0.5f); // Delay before destroying object
        
        yield return null;
    }

    IEnumerator SpeedIncrease()
    {
        yield return new WaitUntil(() => GameManager._score !% 5 == 0);
        _isBoostingComplete = true;

    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        _rb.velocity = new Vector2(0, -_speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if collides with Paddle tag
        if(collision.gameObject.CompareTag("Paddle"))
        {
            // Increases _score
            GameManager._score++; 

            // Audio Player
            if (GameManager._score >= 0)
            {
                _audio.clip = _paddleHit;
            }

            if(GameManager._score % 5 == 0 && GameManager._score > 0)
            {
                _audio.clip = _every5Score;
            }
            _audio.Play(0);
        }

        if(collision.gameObject.CompareTag("Asteroid"))
        {
            StartCoroutine(ObjDestroyed());
        }

        if(collision.gameObject.CompareTag("Restart"))
        {
            StartCoroutine(ObjDestroyed());
        }     
    }
}
