using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] float timeBetweenBullets = 0.15f;
    [SerializeField] GameObject projectile;

    float nextBullet;

    void Awake()
    {
        nextBullet = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (AmmoComponent.instance.CheckIfEmptyAmmo())
        {

        }
        else
        {
            PlayerController playerController = transform.root.GetComponent<PlayerController>();

            if(Input.GetAxisRaw("Fire1") > 0 && nextBullet < Time.time)
            {
                nextBullet = Time.time + timeBetweenBullets;
                Vector3 rot;
                if (playerController.GetPlayerDirection() == -1f)
                    rot = new Vector3(0, -90, 0);
                else
                    rot = new Vector3(0, 90, 0);

                Instantiate(projectile, transform.position, Quaternion.Euler(rot));
                AmmoComponent.instance.DecrementAmmo();
            }

        }
    }
}
