using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] float range = 10f;
    [SerializeField] int damage = 5;
    [SerializeField] float speed = 5f;
    public Transform slashPoint_Transform;
    public float slashPoint_Range = 2f;

    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunLine;

    [SerializeField] Collider[] hitTargets;
    [SerializeField] GameObject particleObject;


    void Awake()
    {
        slashPoint_Transform = transform;
        shootableMask = LayerMask.GetMask("Shootable");
        gunLine = GetComponent<LineRenderer>();

        shootRay.origin = transform.position; // instantiate at the muzzle location
        shootRay.direction = transform.forward;
        gunLine.SetPosition(0, transform.position);

        if(Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //gunLine.SetPosition(1, shootHit.point);

        }
        else
        {
            //gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, shootRay.origin + shootRay.direction * range, speed * Time.deltaTime);
        
        hitTargets = Physics.OverlapSphere(slashPoint_Transform.position, slashPoint_Range);
        foreach (var target in hitTargets)
        {
            if (target.CompareTag("Enemy"))
            {
                //Add Damage
                target.GetComponent<HealthComponent>().TakeDamage(damage);
                Debug.Log("Enemy HITTTTTT!!!");

                Instantiate(particleObject, transform.position, Quaternion.identity);
                
                Destroy(gameObject);
            }
            else if (target.CompareTag("WallPlatform"))
            {
                Destroy(gameObject);

            }
        }

        if(transform.position == shootRay.origin + shootRay.direction * range)
        {
            Destroy(gameObject);
        }

    }


    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, slashRange);

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(slashPoint_Transform.position, slashPoint_Range);
    }

}
