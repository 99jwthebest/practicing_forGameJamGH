using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDeath()
    {
        if (gameObject.CompareTag("Player"))
        {
            UIManager.instance.ActivateLoseMenuUI();
            CountupTimer.instance.SetTimeScale(0f);
            
        }

    }

    public void EnemyDeath()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy is dead!!!");
            AudienceAppraisalMeter.instance.ComboRefillBar(100);
            ScoreManager.instance.IncrementScore(500);
            Destroy(gameObject);

        }
    }
}
