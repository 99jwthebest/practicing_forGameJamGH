using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageComponent : MonoBehaviour
{
    [SerializeField] HealthComponent playerHealthComponent;

    void Start()
    {
        //playerHealthComponent = FindObjectOfType<PlayerController>().GetComponent<HealthComponent>();

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerHealthComponent.TakeDamage(1);
            Debug.Log("Enemy Damaged Player!!!");
        }
    }

}
