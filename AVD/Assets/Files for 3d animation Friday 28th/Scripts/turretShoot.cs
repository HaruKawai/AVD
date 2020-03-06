using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public float frequency = 1f;
    public Transform[] BulletPositions;
    public Animator[] GunsAnimators;
    public GameObject bulletPrefab;
    public int damage = 20;

    void Start() {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private int i = 0;
    IEnumerator Fire()
    {
        GunsAnimators[i].SetTrigger("Fire");
        Instantiate(bulletPrefab, BulletPositions[i].position, BulletPositions[i].rotation);
        i++;
        if (i >= BulletPositions.Length) i = 0;
        yield return new WaitForSeconds(frequency);

        StartCoroutine(Fire());
    }

    //si desactivas el script las corutinas igualmente se ejecutan
    private void OnDisable() {
        StopAllCoroutines();    
    }
    
    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, BulletPositions[0].position, BulletPositions[0].rotation);
        Instantiate(bulletPrefab, BulletPositions[1].position, BulletPositions[1].rotation);
        Instantiate(bulletPrefab, BulletPositions[2].position, BulletPositions[2].rotation);
        Instantiate(bulletPrefab, BulletPositions[3].position, BulletPositions[3].rotation);

    }
}
