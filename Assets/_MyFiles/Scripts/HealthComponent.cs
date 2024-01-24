using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] int maxHealth;

    [SerializeField] DeathComponent deathComponent;

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


            deathComponent.PlayerDeath();
            deathComponent.EnemyDeath();
        }
    }

    public void TakeDamage(float damageValue)
    {
        currentHealth -= damageValue;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
