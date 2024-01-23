using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupComponent : MonoBehaviour
{
    [SerializeField] int scoreForTicket;

    void Start()
    {

    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Player")
        {
            ScoreManager.instance.IncrementTicketCount();
            ScoreManager.instance.IncrementScore(scoreForTicket);
            AudienceAppraisalMeter.instance.ComboRefillBar(20);
            Destroy(gameObject);    
        }
    }

}
