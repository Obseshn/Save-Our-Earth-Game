using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Attacker
{
    [SerializeField] private CosmicObjectsRotator cosmicObjectsRotator;
    [SerializeField] private UFOBullet bullet;
    /*[SerializeField] private float minSize = 1f;*/
    private float shootCD = 5f;
    private float timeBetweenShootInSec = 0.6f;
    

    private void OnEnable()
    {

        healthSystem = new HealthSystem(Random.Range(2, 6));
        transform.LookAt(GameObject.FindGameObjectWithTag("Earth").transform); // !!!
        transform.localScale = SizeChanger.GetRandomChangeSize(minSizeOfAttacker, minSizeOfAttacker * 2) + new Vector3(0, 5, 0); // last Vector is offset
    }

    IEnumerator ActiveShooting()
    {
        yield return new WaitForSeconds(shootCD);
        Shoot();

        // Корутина вызывает сама себя
        StartCoroutine(ActiveShooting());
    }

    private void Update()
    {
        MoveToTheWorldCenter();
        cosmicObjectsRotator.RotateObjectZAxis();
    }
    private void Shoot()
    {
        StartCoroutine(ShootBehaviour());
    }

    private void SpawnNewBullet()
    {
        UFOBullet newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.ChangeMovespeed(moveSpeed + 2f);
        Debug.Log("New bullet exist!");
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
