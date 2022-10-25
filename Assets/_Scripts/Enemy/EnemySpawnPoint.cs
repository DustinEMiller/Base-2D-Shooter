using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    //Implement Pooling System?
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float timeToSpawn = 1.5f;
    [SerializeField] private GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        yield return new WaitForSeconds(timeToSpawn);
        Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
