using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupComponent : MonoBehaviour
{
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
            ScoreManager.instance.IncrementScore(100);
            AudienceAppraisalMeter.instance.ComboRefillBar(20);
        }
    }

}
