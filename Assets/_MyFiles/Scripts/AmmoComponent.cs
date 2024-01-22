using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoComponent : MonoBehaviour
{
    public static AmmoComponent instance;

    [SerializeField] int ammoForPies;
    [SerializeField] int maxAmmo;

    private void Awake()
    {
        instance = this;
        ammoForPies = 0;
        
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void IncrementAmmo()
    {
        ammoForPies++;
        ScoreManager.instance.IncrementPies();
    }

    public void DecrementAmmo()
    {
        ammoForPies--;
        ScoreManager.instance.DecrementPies();

    }

    public int GetAmmo()
    {
        return ammoForPies;
    }

    public bool CheckIfMaxedAmmo()
    {
        if(ammoForPies >= maxAmmo)
        {
            ammoForPies = maxAmmo;
            return true;
        }

        return false;
    }

    public bool CheckIfEmptyAmmo()
    {
        if (ammoForPies <= 0)
        {
            ammoForPies = 0;
            return true;
        }

        return false;
    }
}