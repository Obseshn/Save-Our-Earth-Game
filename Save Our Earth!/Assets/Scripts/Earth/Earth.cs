using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    private HealthSystem healthSystem;
    private CosmicObjectsRotator cosmicObjectsRotator;
    [SerializeField] private CatastropheCounter catastropheCounter;
    private bool isOnCatastrophe = false;
    private void Start()
    {
        cosmicObjectsRotator = GetComponent<CosmicObjectsRotator>();

        healthSystem = new HealthSystem(10);
        healthSystem.OnObjectDied += DestroyPlanet;
        healthSystem.OnObjectTakenDamage += OnTakeDamageBehaviour;

        catastropheCounter.OnCatastropheReady += MakeCatastrophe; 
    }

    private void Update()
    {
        cosmicObjectsRotator.RotateObjectYAxis();
    }
    protected virtual void OnTakeDamageBehaviour()
    {
        Debug.Log(transform.name + " taken damage!");
    }
    protected virtual void DestroyPlanet()
    {
        Debug.Log("Earth has been destroyed! You lose!");
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Attacker>())
        {
            healthSystem.TakeDamage(1);
        }
    }

    private void OnMouseDown()
    {
        if (isOnCatastrophe)
        {
            int randomTrueOrFalse = Random.Range(0, 2);
            if (randomTrueOrFalse == 1)
            {
                isOnCatastrophe = false;
                Debug.Log("Catastrophe has been stopped!");
            }
        }
    }

    private void MakeCatastrophe()
    {
        isOnCatastrophe = true;
        StartCoroutine(CatastropheDelay(5));
    }

    IEnumerator CatastropheDelay(float delayTimeInSec)
    {
        Debug.Log("Catastrophe started!");
        yield return new WaitForSeconds(delayTimeInSec);
        if (isOnCatastrophe)
        {
            healthSystem.TakeDamage(1);
        }
    }
    private void OnDisable()
    {
        healthSystem.OnObjectDied -= DestroyPlanet;
        healthSystem.OnObjectTakenDamage -= OnTakeDamageBehaviour;
    }
}
