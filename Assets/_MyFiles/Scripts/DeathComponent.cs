using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.ProBuilder;

public class DeathComponent : MonoBehaviour
{
    [SerializeField] int scoreForEnemy;
    [SerializeField] GameObject particleObject;

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
            //AudienceAppraisalMeter.instance.IncrementTimeForAudienceDrain(2);
            Instantiate(particleObject, transform.position, Quaternion.identity);
            ScoreManager.instance.IncrementScore(scoreForEnemy);
            ScoreManager.instance.IncrementTotalEnemiesKilled();
            Destroy(gameObject);

        }
    }



}
