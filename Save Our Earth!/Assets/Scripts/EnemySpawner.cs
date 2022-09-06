using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Attacker[] attackers;

    [SerializeField] private float maxSpawnRangeDistance = 10f;
    private float spawnTime = 3f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAttacker", spawnTime, spawnTime);
    }
    private void SpawnRandomAttacker()
    {
        Instantiate(attackers[Random.Range(0, attackers.Length)], GenerateSpawnPosition(), Quaternion.identity);
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
