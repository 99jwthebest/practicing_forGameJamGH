using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {

    }

    void Update()
    {
        if (CountupTimer.instance.TimeStopped())
            return;

        if (currentHealth <= 0)
        {
            UIManager.instance.UpdateHealth();
            currentHealth = maxHealth;

            DeathComponent deathComponent = GetComponent<DeathComponent>();

            deathComponent.PlayerDeath();
            deathComponent.EnemyDeath();
        }
    }

    public void TakeDamage(int damageValue)
    {
        currentHealth -= damageValue;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
