using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    internal enum MovementType
    {
        Right,
        Left,
        Up,
        Down,
    }

    [SerializeField]
    private MovementType movementType;

    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;
    [SerializeField] float travelDistance;
    [SerializeField] Vector3 distancedTraveled;
    [SerializeField] bool movingToEndPos;
    [SerializeField] Vector3 directionToMoveGlobal;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        endPosition = startPosition;

        DirectionForObjectToMove();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateDirectionForObjectToMove();

    }

    //Vector3 DirectionForObjectToMove(MovementType movementType)
    //{
    //    switch (movementType)
    //    {
    //        case MovementType.Right:
    //            transform.Translate(Vector3.right * Time.deltaTime * 3);
    //            break;
    //    }

    //    return;
    //}

    void DirectionForObjectToMove()
    {
        switch (movementType)
        {
            case MovementType.Right:
                endPosition.x += travelDistance;
                distancedTraveled.x = transform.position.x - startPosition.x;
                //transform.Translate(Vector3.right * Time.deltaTime * 3);
                break;
            case MovementType.Left:
                endPosition.x -= travelDistance;
                distancedTraveled.x = transform.position.x - startPosition.x;
                //transform.Translate(Vector3.right * Time.deltaTime * 3);
                break;
            case MovementType.Up:
                endPosition.y += travelDistance;
                distancedTraveled.y = transform.position.y - startPosition.y;
                //transform.Translate(Vector3.right * Time.deltaTime * 3);
                break;
            case MovementType.Down:
                endPosition.y -= travelDistance;
                distancedTraveled.y = transform.position.y - startPosition.y;
                //transform.Translate(Vector3.right * Time.deltaTime * 3);
                break;
        }
    }

    void UpdateDirectionForObjectToMove()
    {
        switch (movementType)
        {
            case MovementType.Right:
                
                distancedTraveled.x = transform.position.x - startPosition.x;
                if (movingToEndPos)
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);

                    if (distancedTraveled.x >= travelDistance)
                    {
                        movingToEndPos = false;
                    }
                }
                else
                {
                    transform.Translate(Vector3.left * speed * Time.deltaTime);

                    if (distancedTraveled.x <= 0)
                    {
                        movingToEndPos = true;

                    }
                }
                break;
            case MovementType.Left:
                distancedTraveled.x = (transform.position.x - startPosition.x) * -1;

                if (movingToEndPos)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * speed);

                    if (distancedTraveled.x >= travelDistance)
                    {
                        movingToEndPos = false;
                    }
                }
                else
                {
                    transform.Translate(Vector3.right * Time.deltaTime * speed);

                    if (distancedTraveled.x <= 0)
                    {
                        movingToEndPos = true;

                    }
                }
                break;
            case MovementType.Up:
                distancedTraveled.y = transform.position.y - startPosition.y;
                if (movingToEndPos)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * speed);

                    if (distancedTraveled.y >= travelDistance)
                    {
                        movingToEndPos = false;
                    }
                }
                else
                {
                    transform.Translate(Vector3.down * Time.deltaTime * speed);

                    if (distancedTraveled.y <= 0)
                    {
                        movingToEndPos = true;

                    }
                }
                //transform.Translate(Vector3.right * Time.deltaTime * 3);
                break;
            case MovementType.Down:
                distancedTraveled.y = (transform.position.y - startPosition.y) * -1;
                if (movingToEndPos)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * speed);

                    if (distancedTraveled.y >= travelDistance)
                    {
                        movingToEndPos = false;
                    }
                }
                else
                {
                    transform.Translate(Vector3.up * Time.deltaTime * speed);

                    if (distancedTraveled.y <= 0)
                    {
                        movingToEndPos = true;

                    }
                }
                break;
        }

        //return directionToMove;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(gameObject.tag != "Enemy")
        {
            if(collision.gameObject.tag == "Player")
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
                //PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                //playerController.onMovingPlatform = false;
                collision.gameObject.transform.SetParent(null);
            }
        }
    }

}
