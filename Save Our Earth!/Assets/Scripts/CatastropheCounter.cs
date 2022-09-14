using System.Collections;
using UnityEngine;
using System;

public class CatastropheCounter : MonoBehaviour
{
    public Action OnCatastropheReady;

    private float timeToCatastrophe;
    private readonly float minCatastropheCoolDown = 10f;

   
    private void Start()
    {
        timeToCatastrophe = UnityEngine.Random.Range(minCatastropheCoolDown, minCatastropheCoolDown * 2);
        StartCoroutine(CatastropheDuration(timeToCatastrophe));
    }

    IEnumerator CatastropheDuration(float durationTime)
    {
        yield return new WaitForSeconds(durationTime);
        OnCatastropheReady?.Invoke();

        timeToCatastrophe = UnityEngine.Random.Range(minCatastropheCoolDown, minCatastropheCoolDown * 2);
        StartCoroutine(CatastropheDuration(timeToCatastrophe));
    }
}
