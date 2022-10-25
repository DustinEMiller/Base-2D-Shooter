using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyRandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawnPointPrefab; //Maybe have this actually spawn the enemy after the 1.5 wait time?
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private float batchSize, batchMultiplier, batchSpawnTime, batchSpawnTimeMultiplier, batchRoundIncrease;
    
    IEnumerator CreateSpawnPointCoroutine()
    {
        var spawnPoint = GetRandomPoint();
        var randomOffset = Random.insideUnitCircle * 5;
        var currentPoint = spawnPoint;
        var timer = 0.2f;

        for(var i = 0; i < batchSize; i++)
        {
            randomOffset = Random.insideUnitCircle * 5;
            currentPoint = spawnPoint + (Vector3)randomOffset;
            
            while (!tileMap.localBounds.Contains(currentPoint))
            {
                randomOffset = Random.insideUnitCircle * 5;
                currentPoint = spawnPoint + (Vector3) randomOffset;
            }

            yield return new WaitForSeconds(timer);
            CreateSpawnPoint(currentPoint);
        }
        
        yield return new WaitForSeconds(batchSpawnTime);
        StartCoroutine(CreateSpawnPointCoroutine());
    }
    
    private void CreateSpawnPoint(Vector3 spawnPoint)
    {
        Instantiate(spawnPointPrefab, spawnPoint, Quaternion.identity);
    }

    private Vector3 GetRandomPoint()
    {
        var x = Random.Range(tileMap.localBounds.min.x, tileMap.localBounds.max.x);
        var y = Random.Range(tileMap.localBounds.min.x, tileMap.localBounds.max.y);
        return new Vector3(x, y, 0.0f);
    }

    private void Start()
    {
        StartCoroutine(CreateSpawnPointCoroutine());
    }
}
