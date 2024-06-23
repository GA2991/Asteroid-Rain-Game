using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] asteroids;
    private float spawnRangeX = 10;
    private float spawnPosY = 20;

    private float startDelay = 2;
    public float spawnInterval;
    private bool isSpawning = false; // Add this flag
    

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
        StartCoroutine(DecreaseSpawnInterval());
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void StartSpawning()
    {
        if (!isSpawning) // Check if spawning is not already scheduled
        {
            isSpawning = true; // Set the flag to true
            InvokeRepeating("SpawnRandomAsteroid", startDelay, spawnInterval);
        }
    }

    IEnumerator DecreaseSpawnInterval()
    {
        while(spawnInterval > 0.5f)
        {
            yield return new WaitForSeconds(30); // Or change back to 30 for your original intent
            spawnInterval = Mathf.Max(spawnInterval - 0.5f, 0.5f);
            CancelInvoke("SpawnRandomAsteroid"); // Cancel any existing invocations
            isSpawning = false; // Reset the flag
            StartSpawning(); // Start spawning with the new interval
        }
    }

    void SpawnRandomAsteroid()
    {
        Vector3 SpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);
        int asteroidIndex = Random.Range(0, asteroids.Length);
        Instantiate(asteroids[asteroidIndex], SpawnPos, asteroids[asteroidIndex].transform.rotation);
    }
}
