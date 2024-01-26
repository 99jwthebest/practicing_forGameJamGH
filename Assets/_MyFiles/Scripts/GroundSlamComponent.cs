using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlamComponent : MonoBehaviour
{
    public static GroundSlamComponent instance;

    [SerializeField] PlayerController playerController;
    [SerializeField] Rigidbody playerRigidbody;

    [SerializeField] bool isSlamming;
    [SerializeField] float timeBetweenSlams = 1f;
    float nextSlam;
    [SerializeField] float coolDown;
    float rechargeSlam;
    [SerializeField] int amountOfSlams;
    [SerializeField] float range = 20f;
    [SerializeField] float damage = 5f;
    [SerializeField] float speed = 5f;
    public Transform slashPoint_Transform;
    public float slashPoint_Range = 2f;

    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunLine;

    Collider[] hitTargets;

    // comboBar
    [SerializeField]
    private int maxComboValue = 100;
    [SerializeField]
    private int currentComboValue;
    //public Slider comboSlider;
    private Coroutine degenCombo;

    [SerializeField] GameObject particleObject;


    void Awake()
    {
        instance = this;

        slashPoint_Transform = transform;
        shootableMask = LayerMask.GetMask("Shootable");
        gunLine = GetComponent<LineRenderer>();

        //shootRay.origin = transform.position; // instantiate at the muzzle location
        //shootRay.direction = transform.forward;
        //gunLine.SetPosition(0, transform.position);

        //if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        //{
        //    gunLine.SetPosition(1, shootHit.point);
        //}
        //else
        //{
        //    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        //}

    }

    private void Start()
    {
        UIManager.instance.UpdateGroundSlamText();
    }

    // Update is called once per frame
    void Update()
    {

        if (rechargeSlam < Time.time)
        {
            UIManager.instance.UpdateGroundSlamText();

        }

        if (Input.GetKeyDown(KeyCode.G) && !isSlamming 
            && !playerController.GetIsGrounded() 
            && nextSlam < Time.time
            && rechargeSlam < Time.time)
        {
            coolDown = 0f;

            StartGroundSlam();
            Debug.Log(" Ground slam?!?!?");
            amountOfSlams--;
            UIManager.instance.UpdateGroundSlamText();


            if (amountOfSlams == 0)
            {
                Debug.Log("Slam Recharge!!!?");
                coolDown = 4f;
                rechargeSlam = Time.time + coolDown;
                amountOfSlams = 4;
            }

        }

    }


    public void StartGroundSlam()
    {

        if (degenCombo != null)
        {
            StopCoroutine(degenCombo);
        }

        degenCombo = StartCoroutine(GroundSlamTravel());
       
    }

    private IEnumerator GroundSlamTravel()
    {
        yield return new WaitForSeconds(.1f);
        Debug.Log("It is heree!!!!!?!?");

        isSlamming = true;

        nextSlam = Time.time + timeBetweenSlams;

        shootRay.origin = transform.position; // instantiate at the muzzle location
        shootRay.direction = -transform.up;
        //gunLine.SetPosition(0, transform.position);

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            //gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

        while (!playerController.GetGroundedRealTime())
        {

            Debug.Log("WHYYYYY!!!!!!!");
            transform.position = Vector3.MoveTowards(transform.position, shootRay.origin + shootRay.direction * range, speed * 0.006f);

            hitTargets = Physics.OverlapSphere(slashPoint_Transform.position, slashPoint_Range);
            foreach (var target in hitTargets)
            {
                if (target.CompareTag("Enemy"))
                {
                    //Add Damage
                    target.GetComponent<HealthComponent>().TakeDamage(2);
                    Debug.Log("Enemy HITTTTTT!!!");
                    //Destroy(gameObject);

                }
                else
                {

                }
            }
            yield return new WaitForSeconds(0.006f);
        }
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);

        playerRigidbody.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
        isSlamming = false;

        Vector3 offsetParticle = new Vector3(0,.5f,0);
        Instantiate(particleObject, transform.position + offsetParticle, Quaternion.identity);
        degenCombo = null;
    }

    public int GetGroundSlamAmount()
    {
        return amountOfSlams;
    }


    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, slashRange);

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(slashPoint_Transform.position, slashPoint_Range);
    }
}
