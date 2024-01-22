using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeComponent : MonoBehaviour
{
    private Animator anim;
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
        //if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        //{
        //    anim.SetBool("hit1", false);
        //}
        //if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        //{
        //    anim.SetBool("hit2", false);
        //}
        //if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        //{
        //    anim.SetBool("hit3", false);
        //    noOfClicks = 0;
        //}

        //if (Time.time - lastClickedTime > maxComboDelay)
        //{
        //    noOfClicks = 0;
        //}

        ////cooldown time
        //if (Time.time > nextFireTime)
        //{
        //    // Check for mouse input
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        if (staminaBar.currentStamina > 14)
        //        {
        //            OnClick();
        //        }

        //    }
        //}

        //if (Input.GetMouseButton(1))
        //{
        //    if (canBlock == true)
        //    {
        //        UseBlock();
        //    }

        //}
        //if (Input.GetMouseButtonUp(1))
        //{
        //    anim.SetBool("isBlocking", false);
        //}

        if (Input.GetMouseButtonDown(1))
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

    //public void StaminAnim()
    //{
    //    staminaBar.UseStamina(15);
    //}

    public void UseBlock()
    {
        canBlock = false;
        anim.SetTrigger("block");
        anim.SetBool("isBlocking", true);
    }

    public void BlockReset()
    {
        canBlock = true;
        anim.ResetTrigger("block");

    }

    public void UseDodge()
    {
        canDodge = false;
        anim.SetTrigger("dodge");
    }

    public void DodgeReset()
    {
        canDodge = true;
        anim.ResetTrigger("dodge");
    }

    public void UseMelee()
    {
        //canMelee = false;
        SlashEM();
        //meleeWeapon.transform.localRotation = Quaternion.Lerp(meleeWeapon.transform.localRotation, endRotation, 1 * Time.deltaTime);
        //anim.SetTrigger("dodge");
    }

    public void MeleeReset()
    {
        canMelee = true;

        //anim.ResetTrigger("dodge");
    }

    void OnClick()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            anim.SetBool("hit1", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            anim.SetBool("hit1", false);
            anim.SetBool("hit2", true);
        }
        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            anim.SetBool("hit2", false);
            anim.SetBool("hit3", true);
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
