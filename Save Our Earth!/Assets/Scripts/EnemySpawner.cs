using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] attackers;

    [SerializeField] private float maxSpawnRangeDistance = 10f;
    private float difficultyCounter;
    private readonly float minimumSpawnTime = 1;
    private float timeBetweenSpawnEnemy = 4f;

    private void Start()
    {
        /*InvokeRepeating("SpawnRandomAttacker", spawnTime + Random.Range(0, 3f), Random.Range(spawnTime, spawnTime * 1.5f));*/
        StartCoroutine(EndlessSpawnEnemy());
    }
    private void SpawnRandomAttacker()
    {
        Instantiate(attackers[Random.Range(0, attackers.Length)], GenerateSpawnPosition(), Quaternion.identity);
    }

    private void Update()
    {
        if (timeBetweenSpawnEnemy > minimumSpawnTime)
        {
            difficultyCounter += Time.deltaTime / 100;
        }
    }

    IEnumerator EndlessSpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(timeBetweenSpawnEnemy - difficultyCounter, (timeBetweenSpawnEnemy * 1.5f) - difficultyCounter));
        SpawnRandomAttacker();
        StartCoroutine(EndlessSpawnEnemy());
    }
    private Vector3 GenerateSpawnPosition()
    {
        float xPos = transform.position.x + Random.Range(-maxSpawnRangeDistance, maxSpawnRangeDistance);
        float yPos = transform.position.y + Random.Range(-maxSpawnRangeDistance, maxSpawnRangeDistance);
        float zPos = transform.position.z + Random.Range(-maxSpawnRangeDistance, maxSpawnRangeDistance);
        return new Vector3(xPos, yPos, zPos);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxSpawnRangeDistance);
    }
}
