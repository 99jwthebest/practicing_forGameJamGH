using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;
    [SerializeField] float enemyTravelDistance;
    [SerializeField] Vector3 distancedTraveled;
    [SerializeField] bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        endPosition = startPosition;
        endPosition.x += enemyTravelDistance;
        distancedTraveled.x = transform.position.x - startPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        distancedTraveled.x = transform.position.x - startPosition.x;

        if(movingRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 3);

            if (distancedTraveled.x >= endPosition.x)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * 3);

            if (distancedTraveled.x <= 0)
            {
                movingRight = true;

            }
        }

    }
}
