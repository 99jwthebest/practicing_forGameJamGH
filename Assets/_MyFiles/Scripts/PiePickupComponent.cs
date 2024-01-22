using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiePickupComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (AmmoComponent.instance.CheckIfMaxedAmmo())
            {

            }
            else
            {
                AmmoComponent.instance.IncrementAmmo();
                ScoreManager.instance.IncrementScore(200);
                AudienceAppraisalMeter.instance.ComboRefillBar(40);

            }
        }
    }
}
