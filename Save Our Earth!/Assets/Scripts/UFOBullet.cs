using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBullet : Attacker
{
    private void OnEnable()
    {
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
