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
    public int spawnAmount; // Amount of spawns

    // Start is called before the first frame update
    void Start()
    {
        // Spawns asteroids depending on the spawn rate
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);   
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
}
