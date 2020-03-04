using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // shooting logic
        //Instantiate(ballPrefab, ballPrefab.position, ballPrefab.rotation);
    
    }

}
