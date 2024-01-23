using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothing = 5f;
    [SerializeField] float verticalSmoothing = 5f;


    [SerializeField] Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - target.position;
        offset = new Vector3(0.5f, 1, -80);

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);


        //if (target.position.y > 20)
        //{
        //    transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(targetCamPos.x, 25, targetCamPos.z), smoothing * Time.deltaTime);
        //}
        //else if(target.position.y > 10)
        //{
        //    transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(targetCamPos.x, 15, targetCamPos.z), smoothing * Time.deltaTime);

        //}
        //else
        //{
        //    transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(targetCamPos.x, 5, targetCamPos.z), smoothing * Time.deltaTime);

        //}

    }
}
