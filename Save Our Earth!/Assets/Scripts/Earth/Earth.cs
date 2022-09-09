using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    [SerializeField] private Material catastropheMaterial;
    [SerializeField] private CatastropheCounter catastropheCounter;

    private HealthSystem healthSystem;
    private CosmicObjectsRotator cosmicObjectsRotator;
    
    private bool isOnCatastrophe = false;
    private MeshRenderer earthMeshRenderer;
    private Material[] defaultMaterials;
    

    private void Start()
    {
        cosmicObjectsRotator = GetComponent<CosmicObjectsRotator>();

        healthSystem = new HealthSystem(10);
        healthSystem.OnObjectDied += DestroyPlanet;
        healthSystem.OnObjectTakenDamage += OnTakeDamageBehaviour;

        catastropheCounter.OnCatastropheReady += MakeCatastrophe;

        earthMeshRenderer = GetComponentInChildren<MeshRenderer>();
        defaultMaterials = earthMeshRenderer.materials;
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
            Destroy(other);
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
                earthMeshRenderer.materials = defaultMaterials;
                Debug.Log("Catastrophe has been stopped!");
            }
        }
    }

    private void MakeCatastrophe()
    {
        isOnCatastrophe = true;

        Color randomColor = new Color(Random.Range(0,1f), Random.Range(0, 1f),/*blue: */  0, Random.Range(0, 1f)); // 3rd is zero because it's default color of earth
        catastropheMaterial.color = randomColor;

        earthMeshRenderer.material = catastropheMaterial;
        StartCoroutine(CatastropheDelay(5));
    }

    IEnumerator CatastropheDelay(float delayTimeInSec)
    {
        Debug.Log("Catastrophe started!");
        yield return new WaitForSeconds(delayTimeInSec);
        if (isOnCatastrophe)
        {
            healthSystem.TakeDamage(10);
        }
    }
    private void OnDisable()
    {
        healthSystem.OnObjectDied -= DestroyPlanet;
        healthSystem.OnObjectTakenDamage -= OnTakeDamageBehaviour;
    }
}
