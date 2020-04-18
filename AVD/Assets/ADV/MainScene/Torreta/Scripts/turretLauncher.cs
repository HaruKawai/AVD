using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform Hand;
    
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            GetComponentInParent<Animator>().SetTrigger("Turret");
            //StartCoroutine(Shoot());
        }
    }
    void CastSpell() 
    {
        particle.Play();
    }
    void LaunchTurret()
    {
        Instantiate(ballPrefab, Hand.position, transform.rotation);
    }

}
