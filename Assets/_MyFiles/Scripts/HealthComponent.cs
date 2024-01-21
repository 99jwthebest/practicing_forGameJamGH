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
        if(currentHealth <= 0)
        {
            UIManager.instance.UpdateHealth();
            currentHealth = 0;
            Debug.Log("You are Dead!!!!");

            UIManager.instance.ActivateLoseMenuUI();
            //Time.timeScale = 0f;
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
