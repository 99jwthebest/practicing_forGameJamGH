using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWallSlideCollider : MonoBehaviour
{
    [SerializeField] Collider wallSlideCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "WallSlide")
        {
            wallSlideCollider.enabled = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "WallSlide")
        {
            wallSlideCollider.enabled = false;

        }
    }
}
