using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageComponent : MonoBehaviour
{
    [SerializeField] HealthComponent playerHealthComponent;
    [SerializeField] int damagePlayer;

    public Animator enemy_Animator;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0f;
    float maxComboDelay = 1;

    //public GameObject meleeWeapon;
    public bool canDodge;
    public bool canBlock;
    public bool canMelee;
    public Quaternion endRotation;
    public float rotation = 10f;

    //public float slashRange = 3f;
    public Transform slashPoint_Transform;
    public float slashPoint_Range = 2f;

    //StaminaBar staminaBar;
    public bool enemyHasAnim;
    public bool canAttack;



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerHealthComponent.TakeDamage(damagePlayer);

            UIManager.instance.UpdateHealth();
            Debug.Log("Enemy Damaged Player!!!");
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        //staminaBar = GetComponent<StaminaBar>(); //searches inspector for component

        //anim = GetComponent<Animator>();
        //canDodge = true;
        //canBlock = true;
        canMelee = true;
        //endRotation = meleeWeapon.transform.localRotation;
        //endRotation.z = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyHasAnim)
            return;

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

    public void SlashEM()
    {
        

        Debug.Log("You swung your sword!!");
        Collider[] hitTargets = Physics.OverlapSphere(slashPoint_Transform.position, slashPoint_Range);
        foreach (var target in hitTargets)
        {
            if (target.CompareTag("Player"))
            {
                if (canMelee == true)
                {
                    // Attack player
                    canMelee = false;
                    enemy_Animator.SetTrigger("Attack");
                    target.GetComponent<HealthComponent>().TakeDamage(1);
                    UIManager.instance.UpdateHealth();
                    Debug.Log("Enemy Slashed!!!");
                }
                //Add Damage
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

    public void MeleeReset()
    {
        canMelee = true;
        enemy_Animator.ResetTrigger("Attack");
    }




    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, slashRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(slashPoint_Transform.position, slashPoint_Range);
    }



}
