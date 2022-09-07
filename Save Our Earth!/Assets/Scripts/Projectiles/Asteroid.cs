using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Attacker
{
    [SerializeField] private CosmicObjectsRotator cosmicObjectsRotator;

    private float sizeOfAsteroid = 3f;
    public Asteroid(float size)
    {
        sizeOfAsteroid = size;   
    }

    private void Update()
    {
        cosmicObjectsRotator.RotateObjectAllAxis();
        MoveToTheWorldCenter();
    }

    protected override void DestroyAttacker()
    {
        Debug.Log("Size of asteroid: " + sizeOfAsteroid);
        if (sizeOfAsteroid == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                /*Asteroid newAsteroid = new Asteroid(Random.Range(3 - 1f, 3 - 0.5f));*/
                Asteroid newAsteroid = Instantiate(this, transform.position, Quaternion.identity);
                newAsteroid.sizeOfAsteroid = Random.Range(sizeOfAsteroid - 1f, sizeOfAsteroid - 0.5f);
                Debug.Log("Child of asteroid created!");
            }
        }
        else if (sizeOfAsteroid <= 1)
        {
            base.DestroyAttacker();
        }
        else
        {
            for (int i = 0; i < sizeOfAsteroid; i++)
            {
                Asteroid newAsteroid = Instantiate(this, transform.position, Quaternion.identity);
                newAsteroid.sizeOfAsteroid = sizeOfAsteroid - 1f;
                Debug.Log("Child of asteroid created!");
            }
        }
    }
}
