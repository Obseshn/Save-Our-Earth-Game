using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : Attacker
{
    private void OnEnable()
    {
        healthSystem = new HealthSystem(Random.Range(2, 6));
        
        transform.localScale = SizeChanger.GetRandomChangeSize(minSizeOfAttacker, minSizeOfAttacker * 2) ;
    }
    private void Update()
    {
        MoveToTheWorldCenter();
    }
}
