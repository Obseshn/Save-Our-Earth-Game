using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Attacker
{
    private float shootCD = 3f;
    [SerializeField] private UFOBullet bullet;
    private float timeBetweenShootInSec = 0.25f;

    private void Start()
    {
        healthSystem = new HealthSystem(Random.Range(2, 6));
        StartCoroutine(ActiveShooting());
    }

    IEnumerator ActiveShooting()
    {
        yield return new WaitForSeconds(shootCD);
        Shoot();

        // �������� �������� ���� ����
        StartCoroutine(ActiveShooting());
    }

    void Update()
    {
        cosmicObjectsRotator.RotateObjectYAxis();
    }

    private void Shoot()
    {
        StartCoroutine(ShootBehaviour());
    }

    private void SpawnNewBullet()
    {
        UFOBullet newBullet = Instantiate(bullet);
        newBullet.ChangeMovespeed(moveSpeed + 1f);
    }
    IEnumerator ShootBehaviour()
    {
        SpawnNewBullet();
        yield return new WaitForSeconds(timeBetweenShootInSec);
        SpawnNewBullet();
        yield return new WaitForSeconds(timeBetweenShootInSec);
        SpawnNewBullet();
    }
}
