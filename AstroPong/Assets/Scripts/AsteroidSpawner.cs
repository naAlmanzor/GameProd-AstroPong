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
    static float spawnAmount = 1; // Amount of spawns
    private bool isDone = false;
    [SerializeField] public bool isDemoView = false;
    private float moduloScore;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroids());   
    }

    void Update()
    {
        // Checks score and bool. Also checks if spawn amount is less than 5 
       if(!isDone && GameManager._score > 0 && GameManager._score % 3 == 0 && spawnAmount < 3)
       {
            isDone = true;
            StartCoroutine(Score());
       }

       if(GameManager._playerHealth == 0)
       {
            spawnAmount = 1;
       }
    }

    private void Spawner()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
    
            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion spawnRotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, spawnRotation);

            // Randomizes size ansd trajectory
            asteroid._size = Random.Range(asteroid._minSize, asteroid._maxSize);
            asteroid.SetTrajectory(spawnRotation * -spawnDirection);
        }
    }

    IEnumerator SpawnAsteroids()
    {
        // When Demo View is active
        if(isDemoView)
        {
            InvokeRepeating(nameof(Spawner), this.spawnRate, this.spawnRate);
        }

        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space) && !isDemoView);
        // Spawns asteroids depending on the spawn rate
        InvokeRepeating(nameof(Spawner), this.spawnRate, this.spawnRate);
    }

    IEnumerator Score()
    {
        spawnAmount++;
        moduloScore = GameManager._score;
        yield return new WaitUntil(() => GameManager._score !% 3 == 0);
        isDone = false;
    }
}
