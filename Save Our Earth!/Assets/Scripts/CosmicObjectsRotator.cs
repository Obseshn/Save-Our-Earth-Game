using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicObjectsRotator : MonoBehaviour
{
    private readonly float minRotationSpeed = 10;
    private float rotationSpeed;

    private void Start()
    {
        rotationSpeed = Random.Range(minRotationSpeed, minRotationSpeed * 3);
    }
    public void RotateObjectAllAxis()
    {
        transform.Rotate(Vector3.one * rotationSpeed * Time.deltaTime);
    }

    public void RotateObjectYAxis()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void RotateObjectZAxis()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
