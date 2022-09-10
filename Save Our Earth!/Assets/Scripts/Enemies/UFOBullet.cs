using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBullet : Attacker
{
    private void OnEnable()
    {
        healthSystem = new HealthSystem(Random.Range(2, 6));
        transform.LookAt(FindObjectOfType<Earth>().transform); // !!!
    }
    public void ChangeMovespeed(float newMovespeed)
    {
        moveSpeed = newMovespeed;
        Debug.Log("New bullet movespeed: " + moveSpeed);
    }

    private void Update()
    {
        MoveToTheWorldCenter();
    }
}
