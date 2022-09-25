using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlanet : Attacker
{
    [SerializeField] private CosmicObjectsRotator cosmicObjectsRotator;

    private void OnEnable()
    {
        healthSystem = new HealthSystem(Random.Range(4, 8));
        transform.localScale = SizeChanger.GetRandomChangeSize(minSizeOfAttacker, minSizeOfAttacker * 2);
    }
    private void Update()
    {
        cosmicObjectsRotator.RotateObjectAllAxis();
        MoveToTheWorldCenter();
    }
}
