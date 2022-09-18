using UnityEngine;
using System;

public class Attacker : MonoBehaviour
{
    [SerializeField] protected AudioClip deathSound;
    [SerializeField] private int damage;
    protected HealthSystem healthSystem;
    protected float moveSpeed;
    [SerializeField] private float minMoveSpeed = 1;
    [SerializeField] protected float minSizeOfAttacker;
    public static Action OnAttackerDied;
    [SerializeField] private AudioClip onMouseDownSound;
    [SerializeField] private ParticleSystem destroyParticle;
    
    private void Start()
    {
        healthSystem.OnObjectDied += DestroyAttacker;
        healthSystem.OnObjectTakenDamage += OnTakeDamageBehaviour;
        
        moveSpeed = UnityEngine.Random.Range(minMoveSpeed, minMoveSpeed * 3);
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
    public virtual void DestroyAttacker()
    {
        OnAttackerDied?.Invoke();
        destroyParticle.Play();
        Instantiate(destroyParticle, transform.position, Quaternion.identity);
        Debug.Log(transform.name + " has been destroyed!");
        SoundManager.Instance.PlaySound(deathSound);
        Destroy(gameObject);
    }
    

    private void OnMouseDown()
    {
        Debug.Log("Player hits attacker!");
        SoundManager.Instance.PlayUISound(onMouseDownSound);
        healthSystem.TakeDamage(1);
    }

    private void OnDisable()
    {
        healthSystem.OnObjectDied -= DestroyAttacker;
        healthSystem.OnObjectTakenDamage -= OnTakeDamageBehaviour;
    }
}
