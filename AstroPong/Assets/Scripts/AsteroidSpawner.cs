using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float trajectoryVariance; // Trajectory for asteroid spawns
    public float spawnRate; // Delay between each spawn
    public float spawnDistance; // Distance between
    public float spawnAmount; // Amount of spawns
    private bool isDone = false;
    private float moduloScore;

    // Start is called before the first frame update
    void Start()
    {
        // Spawns asteroids depending on the spawn rate
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
        
    }

    void Update()
    {
        // Checks score and bool. Also checks if spawn amount is less than 5 
       if(!isDone && GameManager.score > 0 && GameManager.score % 10 == 0 && spawnAmount < 5)
       {
            StartCoroutine(Score());
            isDone = true;
            StartCoroutine(Waiter());
       }
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
    
            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion spawnRotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, spawnRotation);

            // Randomizes size ansd trajectory
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(spawnRotation * -spawnDirection);
        }
    }

    IEnumerator Score()
    {
        spawnAmount++;
        moduloScore = GameManager.score;
        StopCoroutine(Score());
        yield return null;
    }

    IEnumerator Waiter()
    {
        yield return new WaitUntil(() => GameManager.score > moduloScore); // Waiter before turning bool false again
        isDone = false;
        StopCoroutine(Waiter());
    }
}
