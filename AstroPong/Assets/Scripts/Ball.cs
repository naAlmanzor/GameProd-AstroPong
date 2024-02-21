using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    float speed = 2.5f;

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
        rb.velocity = -transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if collides with Paddle tag
        if(collision.gameObject.CompareTag("Paddle"))
        {
            // Increases score
            GameManager.score++;
        }

        // Changes speed every 10 points
        if(GameManager.score % 10 == 0)
        {
            Debug.Log("Changed Speed");
        }
    }
}
