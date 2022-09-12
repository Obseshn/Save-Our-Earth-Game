using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEarth : MonoBehaviour
{
    [SerializeField] private CosmicObjectsRotator cosmicObjectsRotator;

    private void Update()
    {
        cosmicObjectsRotator.RotateObjectYAxis();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Attacker>())
        {
            Destroy(other.gameObject);
        }
    }

}
