using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Spawner : MonoBehaviour
{
    public Asteroids asteroidPrefab;
    public float spawnDistance = 15f;
    public float spawnRate = 2f;
    public int spawnAmount = 1;
    public float trajectoryVariance = 15f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = transform.position + (spawnDirection * spawnDistance);
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation =  Quaternion.AngleAxis(variance, Vector3.forward);
            Asteroids asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);

            Vector2 trajectory = rotation * -spawnDirection;
            asteroid.SetTrajectory(trajectory);
        }
    }

}
