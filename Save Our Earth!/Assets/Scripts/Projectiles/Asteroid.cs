using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Attacker
{
    [SerializeField] private CosmicObjectsRotator cosmicObjectsRotator;

    [SerializeField] private float sizeOfAsteroid;

    private void OnEnable()
    {
        healthSystem = new HealthSystem(Random.Range(2, 6));
    }
    public Asteroid(float size)
    {
        
    }

    private void ChangeStagesOfAsteroid(float size)
    {
        if (size < 1)
        {
            base.DestroyAttacker();
        }
        sizeOfAsteroid = size;

        healthSystem.currentHealth = (int)size;

        Vector3 newSize = new Vector3(size / 3, size / 3, size / 3); // 3 - just koefficient value
        transform.localScale = newSize;
    }

    private void Update()
    {
        cosmicObjectsRotator.RotateObjectAllAxis();
        MoveToTheWorldCenter();
    }

    private void SpawnChildAsteroids(int countToSpawn)
    {
        for (int i = 0; i < countToSpawn; i++)
        {
            Asteroid newAsteroid = Instantiate(this, transform.position, Quaternion.identity);
            newAsteroid.ChangeStagesOfAsteroid(Random.Range(sizeOfAsteroid - 1, sizeOfAsteroid - 0.5f));
            Debug.Log("Child of asteroid created!");
        }
    }
    protected override void DestroyAttacker()
    {
        Debug.Log("Size of asteroid: " + sizeOfAsteroid);
        if (Random.Range(0, 3) == 1)
        {
            base.DestroyAttacker();
            return;
        }

        if (sizeOfAsteroid == 0)
        {
            sizeOfAsteroid = Random.Range(2, 3.01f);
            SpawnChildAsteroids((int)sizeOfAsteroid);
        }
        else if (sizeOfAsteroid < 1)
        {
            base.DestroyAttacker();
            return;
        }
        else
        {
            SpawnChildAsteroids((int)sizeOfAsteroid);
        }
        Debug.Log("Size: " + sizeOfAsteroid);
        base.DestroyAttacker();
    }
}
