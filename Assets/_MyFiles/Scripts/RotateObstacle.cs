using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    [SerializeField] Vector3 _rotationForObstacle;
    [SerializeField] float speed;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(_rotationForObstacle * speed * Time.deltaTime);

    }
}
