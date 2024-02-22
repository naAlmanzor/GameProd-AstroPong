using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    float speed = 2f; 

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
            Debug.Log(speed);
        }

        // Increases speed every 5 points if score is greater than 0, 
        // checks if speed is more than 7.5
        if(GameManager.score % 5 == 0 && GameManager.score > 0 && speed < 7.5f)
        {   
            speed += 0.5f;
            rb.velocity = new Vector2(0, -speed);
        }
    }
}
