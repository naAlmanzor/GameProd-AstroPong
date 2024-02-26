using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    float speed = 2f;
    MenuManager menuUI;

    // Start is called before the first frame update
    void Start()
    {
        //Starting velocity for Ball
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(WaitToStart());
    }

    // Update is called once per frame
    void Update()
    {
    }


    // Waits 1.5 seconds before starting game
    private IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1.5f);
        rb.velocity = new Vector2(0, -speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if collides with Paddle tag
        if(collision.gameObject.CompareTag("Paddle"))
        {
            // Increases score
            GameManager.score++; 
            // Debug.Log(speed);
            
        }

        if(collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.CompareTag("Restart"))
        {
            GameManager.playerHealth-=1;
            Debug.Log(GameManager.playerHealth);
            Scene currentScene = SceneManager.GetActiveScene();
            
            if(GameManager.playerHealth != 0)
            {
                SceneManager.LoadScene(currentScene.buildIndex);
            }
            
            else
            {
                SceneManager.LoadScene(0);
            }
        }

        // Increases speed every 5 points if score is greater than 0, 
        // checks if speed is more than 7.5
        if(GameManager.score % 5 == 0 && GameManager.score > 0 && speed < 6f)
        {   
            speed += 0.5f;

            if(transform.position.y < 0)
            {
                rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            }

            if(transform.position.y > 0)
            {
                rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
            }
        }
    }
}
