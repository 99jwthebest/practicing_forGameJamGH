using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeComponent : MonoBehaviour
{
    public Animator playerAnim;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0f;
    float maxComboDelay = 1;

    public GameObject meleeWeapon;
    public bool canDodge;
    public bool canBlock;
    public bool canMelee;
    public Quaternion endRotation;
    public float rotation = 10f;

    //public float slashRange = 3f;
    public Transform slashPoint_Transform;
    public float slashPoint_Range = 2f;
    public GameObject weapon;

    //StaminaBar staminaBar;


    // Start is called before the first frame update
    void Start()
    {
        //staminaBar = GetComponent<StaminaBar>(); //searches inspector for component

        //anim = GetComponent<Animator>();
        //canDodge = true;
        //canBlock = true;
        canMelee = true;
        endRotation = meleeWeapon.transform.localRotation;
        endRotation.z = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.F))
        {

            //UseDodge();
            if (canMelee == true)
            {
                UseMelee();
            }
            else
            {
                Debug.Log("Can't Melee Yet");
            }
        }
    }

    public void SlashEM()
    {
        weapon.SetActive(true);
        canMelee = false;
        playerAnim.SetTrigger("MeleeAttack");
        Debug.Log("You swung your sword!!");
        Collider[] hitTargets = Physics.OverlapSphere(slashPoint_Transform.position, slashPoint_Range);
        foreach (var target in hitTargets)
        {

            if (target.CompareTag("Enemy"))
            {
                //Add Damage
                target.GetComponent<HealthComponent>().TakeDamage(1);
                Debug.Log("Enemy Slashed!!!");
            }
        }
    }


    public void UseMelee()
    {
        //canMelee = false;
        SlashEM();
        //meleeWeapon.transform.localRotation = Quaternion.Lerp(meleeWeapon.transform.localRotation, endRotation, 1 * Time.deltaTime);
        //anim.SetTrigger("dodge");
    }
    public void UseMeleeDamage()
    {

    }
    public void MeleeReset()
    {
        canMelee = true;

        playerAnim.ResetTrigger("MeleeAttack");
        weapon.SetActive(false);
    }



    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, slashRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(slashPoint_Transform.position, slashPoint_Range);
    }
}
