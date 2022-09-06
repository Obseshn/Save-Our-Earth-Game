using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Attacker
{
    [SerializeField] protected CosmicObjectsRotator cosmicObjectsRotator;

    private float sizeOfAsteroid;
    public Asteroid(float size)
    {
        sizeOfAsteroid = size;
        healthSystem.currentHealth = (int)(size);
    }

    private void Update()
    {
        cosmicObjectsRotator.RotateObjectAllAxis();
        MoveToTheWorldCenter();
    }

    protected override void DestroyAttacker()
    {
        if (sizeOfAsteroid <= 1)
        {
            base.DestroyAttacker();
        }
        else
        {
            for (int i = 0; i < sizeOfAsteroid; i++)
            {
                Instantiate(new Asteroid(Random.Range(sizeOfAsteroid - 1f, sizeOfAsteroid - 0.5f)));
            }
        }
    }
}
