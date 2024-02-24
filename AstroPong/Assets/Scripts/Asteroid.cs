using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: System.Numerics is removed for Vector2 lines of code to function
public class Asteroid : MonoBehaviour
{
  //Referencing this: https://www.youtube.com/watch?v=wzQ9Xn406wc
  //Set starting asteroid size
  public int size = 3;


  private void Start()
  {
    //Scale based on the size
    transform.localScale = 0.5f * size * Vector3.one;

    //Applies Movement, bigger = slower smaller = faster
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    Vector2 direction = new Vector2(Random.value, Random.value).normalized;
    float spawnSpeed = Random.Range(4f - size, 5f - size);
    rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);

    //Register creation
    // GameManager.asteroidCount += 1;
  }

}
