using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int damage = 20;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }else if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(Shoot2());
        }
    }
    void Shoot() 
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
    IEnumerator Shoot2() 
    {
        // shooting logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        //if (hitInfo && hitInfo.transform.tag != "Item")
        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.transform.position);
        }else {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }
        lineRenderer.enabled = true;
        //wait one frame
        yield return new WaitForSeconds(0.02f);
        lineRenderer.enabled = true;
    }
}
