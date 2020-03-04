using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3D : MonoBehaviour
{
    public LayerMask layermask;
    public float speed = 5f;
    public int damage = 10;
    public Rigidbody rb;
    public GameObject impactEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }
    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(collision.name);
        //El usar mascaras de layers es para comprobar SOLO los layers que quieras
        if (layermask == (layermask | (1 << collision.gameObject.layer)))
        {
            rb.Sleep();
            GetComponent<Animator>().SetTrigger("Die");
        }
        /*
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (collision.tag != "Item")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        */
    }

}
