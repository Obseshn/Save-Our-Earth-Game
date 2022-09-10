using System;

public class HealthSystem
{
    public int maxHealth;
    public int currentHealth;

    public Action OnObjectDied;
    public Action OnObjectTakenDamage;

    public HealthSystem(int startHealth)
    {
        maxHealth = startHealth;
        currentHealth = maxHealth;
    }
    public void TakeDamage(int amountOfDamage)
    {
        if (amountOfDamage >= currentHealth)
        {
            SendDieMessage();
            return;
        }

        OnObjectTakenDamage?.Invoke(); 
        currentHealth -= amountOfDamage;
    }

    private void SendDieMessage()
    {
        OnObjectDied?.Invoke();
    }
}
