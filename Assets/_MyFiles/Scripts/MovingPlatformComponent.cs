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
    //[SerializeField] Rigidbody platformRigidbody;
    //[SerializeField] PlayerController playerController;
    [SerializeField] bool delayForMoving;
    [SerializeField] float delayWhenToStartMoving;

    void Start()
    {
        destination = endPosition;
        moveDir = (destination.position - transform.position).normalized;
        StartCoroutine(startMovingObject());
    }

    private void FixedUpdate()
    {
        if(!delayForMoving)
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
        //platformRigidbody.AddForce(moveDir * speed, ForceMode.Force);
        //platformRigidbody.velocity = moveDir * speed;


        //transform.position = Vector3.Lerp(transform.position, destination.position, speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, destination.position) < 0.2)
        {
            if(destination == startPosition)
            {
                destination = endPosition;
                //platformRigidbody.Sleep();
            }
            else
            {
                destination = startPosition;
                //platformRigidbody.Sleep();
            }

            moveDir = (destination.position - transform.position).normalized;
        }
    }

    private IEnumerator startMovingObject()
    {
        yield return new WaitForSeconds(delayWhenToStartMoving);
        delayForMoving = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (gameObject.tag != "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Are yoU DOING THIS!!?!?!?");
                collision.gameObject.transform.SetParent(transform);
                //playerController.MoveCharacterOnMovingPlatforms();

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
                //playerController.MoveCharacterOffMovingPlatforms();
            }
        }
    }
}
