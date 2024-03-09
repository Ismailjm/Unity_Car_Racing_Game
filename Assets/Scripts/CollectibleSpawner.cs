using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab; // Reference to the collectible prefab
    [SerializeField] private float spawnDelay = 1.0f; // Delay between creating new collectibles (seconds)
    [SerializeField] private float collectibleHeight = 4.0f; // Height above the road to spawn collectibles
    [SerializeField] private float spawnRadius = 18.0f; // Radius around the road where collectibles can spawn
    [SerializeField] private int maxCollectibles = 1; // Maximum number of collectibles

    private float timer = 0.0f; // Timer for controlling collectible creation
    private int spawnedCollectibles = 0; // Number of currently spawned collectibles

    private Transform collectiblesParent; // Parent transform for the spawned collectibles

    void Start()
    {
        // Assume you've set the parent in the scene with a specific name, replace "CollectiblesParent" with the actual name.
        collectiblesParent = this.transform.parent.gameObject.transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Create a new collectible after spawn delay and if the limit is not reached
        if (timer >= spawnDelay && spawnedCollectibles < maxCollectibles)
        {
            Vector3 randomSpawnPosition = GetRandomSpawnPosition();
            CreateCollectible(randomSpawnPosition);
            timer = 0.0f; // Reset timer after creating a new collectible
            spawnedCollectibles++; // Increment the count of spawned collectibles
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Randomly generate a position along the x-axis within the specified radius
        float randomX = Random.Range(-spawnRadius, spawnRadius);
        Vector3 spawnPosition = new Vector3(randomX, collectibleHeight, transform.position.z);

        return spawnPosition;
    }

    private void CreateCollectible(Vector3 position)
    {
        GameObject newCollectible = Instantiate(collectiblePrefab, position, Quaternion.identity);
        newCollectible.transform.parent = collectiblesParent; // Set the parent to the specified parent
    }

    void LateUpdate()
    {
        // Check if the parent is destroyed, then destroy the script's GameObject (this CollectibleSpawner)
        if (collectiblesParent == null)
        {
            Destroy(gameObject);
        }
    }
}