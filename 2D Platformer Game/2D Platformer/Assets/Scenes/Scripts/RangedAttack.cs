using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    
    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire1"))
       {
            Shoot();
       } 
    }


    void Shoot()
    {
        Instantiate(projectile,firePoint.position,firePoint.rotation);
    }

}
