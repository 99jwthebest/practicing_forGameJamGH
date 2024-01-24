using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformComponent : MonoBehaviour
{

    [SerializeField] Transform startPosition;
    [SerializeField] Transform endPosition;
    [SerializeField] Transform destination;
    [SerializeField] Vector3 moveDir;
    [SerializeField] float speed;

    void Start()
    {
        destination = endPosition;
        moveDir = (destination.position - transform.position).normalized;

    }

    private void FixedUpdate()
    {
        UpdateDirectionForObjectToMove();
        
    }

    void Update()
    {

    }

    private void LateUpdate()
    {
        
    }


    void UpdateDirectionForObjectToMove()
    {
        transform.position += moveDir * speed * Time.fixedDeltaTime;
        if(Vector3.Distance(transform.position, destination.position) < 0.2)
        {
            if(destination == startPosition)
            {
                destination = endPosition;
            }
            else
            {
                destination = startPosition;
            }

            moveDir = (destination.position - transform.position).normalized;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (gameObject.tag != "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Are yoU DOING THIS!!?!?!?");
                collision.gameObject.transform.SetParent(transform);
            }
        }
    }



    private void OnTriggerExit(Collider collision)
    {
        if (gameObject.tag != "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.transform.SetParent(null);
            }
        }
    }
}
