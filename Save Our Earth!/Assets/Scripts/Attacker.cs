using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int damage;
    protected CosmicObjectsRotator cosmicObjectsRotator;
    protected HealthSystem healthSystem;
    protected float moveSpeed;
    private readonly int minMoveSpeed = 1;


    private void Start()
    {
        cosmicObjectsRotator = GetComponent<CosmicObjectsRotator>();

        
        healthSystem.OnObjectDied += DestroyAttacker;
        healthSystem.OnObjectTakenDamage += OnTakeDamageBehaviour;
        
        moveSpeed = Random.Range(minMoveSpeed, minMoveSpeed * 3);
    }
    public virtual void MoveToTheWorldCenter()
    {
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
    private void Update()
    {
        MoveToTheWorldCenter();
    }

    private void OnMouseDown()
    {
        healthSystem.TakeDamage(1);
    }

    private void OnDisable()
    {
        healthSystem.OnObjectDied -= DestroyAttacker;
        healthSystem.OnObjectTakenDamage -= OnTakeDamageBehaviour;
    }
}
