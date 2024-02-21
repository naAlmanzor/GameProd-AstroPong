using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
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

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1.5f);
        rb.velocity = -transform.up * speed;
    }
}
