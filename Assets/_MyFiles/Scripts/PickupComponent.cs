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
            Debug.Log("What in the flying fucker!!!");
        }
    }

}
