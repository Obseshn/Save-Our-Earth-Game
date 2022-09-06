using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBullet : Attacker
{
    private void Start()
    {
        healthSystem = new HealthSystem(Random.Range(2, 6));
    }
    public void ChangeMovespeed(float newMovespeed)
    {
        moveSpeed = newMovespeed;
    }
}
