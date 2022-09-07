using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int damage;
    protected HealthSystem healthSystem;
    protected float moveSpeed;
    [SerializeField] private float minMoveSpeed = 1;


    private void Start()
    {
        healthSystem = new HealthSystem(Random.Range(2, 6));
        healthSystem.OnObjectDied += DestroyAttacker;
        healthSystem.OnObjectTakenDamage += OnTakeDamageBehaviour;

        moveSpeed = Random.Range(minMoveSpeed, minMoveSpeed * 3);
    }

    public virtual void MoveToTheWorldCenter()
    {
        Debug.Log(transform.name + " is moving to the center! " + "Speed : " + moveSpeed);
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, moveSpeed * Time.deltaTime);
    }

    protected virtual void OnTakeDamageBehaviour()
    {
        Debug.Log(transform.name + " taken damage!");
    }
    protected virtual void DestroyAttacker()
    {
        Debug.Log(transform.name + " has been destroyed!");
        Destroy(gameObject);
    }
    

    private void OnMouseDown()
    {
        Debug.Log("Player hits attacker!");
        healthSystem.TakeDamage(1);
    }

    private void OnDisable()
    {
        healthSystem.OnObjectDied -= DestroyAttacker;
        healthSystem.OnObjectTakenDamage -= OnTakeDamageBehaviour;
    }
}
