using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform Hand;
    
    public ParticleSystem particle;

    // If the key "k" is down, activates the cast Spel animation of the main character
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            GetComponent<Animator>().SetTrigger("Turret");
        }
    }

    //An event that is called to play the particles
    void CastSpell() 
    {
        particle.Play();
    }

    //An event that is called to instantiate the turret
    void LaunchTurret()
    {
        Instantiate(ballPrefab, Hand.position, transform.rotation);
    }

}
