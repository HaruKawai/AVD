using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Starting in 2 seconds.
// a projectile will be launched every 0.3 seconds

public class controladorTiempo : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        InvokeRepeating("LaunchProjectile", 1.6f, 6.0f);
        InvokeRepeating("StopLaunchProjectile", 4.6f, 6.0f);
        
        InvokeRepeating("LaunchProjectile2", 0f, 2.0f);
        InvokeRepeating("StopLaunchProjectile2", 0.5f, 2.0f);
    }

    void LaunchProjectile()
    {
        animator.SetBool("Walk", true);
    }
    void StopLaunchProjectile()
    {
        animator.SetBool("Walk", false);
    }


    void LaunchProjectile2()
    {
        animator.SetBool("Toma", true);
    }
    void StopLaunchProjectile2()
    {
        animator.SetBool("Toma", false);
    }
}