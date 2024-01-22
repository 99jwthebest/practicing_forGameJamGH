using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlamComponent : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

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

    void Awake()
    {
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartGroundSlam();
            Debug.Log("What the fuck?!?!?");

        }

    }


    public void StartGroundSlam()
    {

        //currentComboValue += refillBar;
        //SetComboValue(currentComboValue);

        if (degenCombo != null)
        {
            StopCoroutine(degenCombo);
        }

        degenCombo = StartCoroutine(GroundSlamTravel());

        //if (currentComboValue >= maxComboValue)
        //{
        //    currentComboValue = maxComboValue;
        //}
        //if (currentComboValue <= 0)
        //{
        //    currentComboValue = 0;
        //}
    }

    private IEnumerator GroundSlamTravel()
    {
        yield return new WaitForSeconds(.1f);
        Debug.Log("It is heree!!!!!?!?");

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

        while (!playerController.GetIsGrounded())
        {

            Debug.Log("WHYYYYY!!!!!!!");
            transform.position = Vector3.MoveTowards(transform.position, shootRay.origin + shootRay.direction * range, speed * Time.deltaTime);

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
            yield return new WaitForSeconds(.01f);
        }

        //comboNumber = 0;
        //comboNumberText.text = "Combo: " + comboNumber;
        //comboObj.SetActive(false);

        degenCombo = null;
    }


    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, slashRange);

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(slashPoint_Transform.position, slashPoint_Range);
    }
}
