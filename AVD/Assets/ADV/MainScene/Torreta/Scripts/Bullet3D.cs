using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;
using CreatorKitCodeInternal;

public class Bullet3D : MonoBehaviour
{
    public float speed = 5f;

    //Damages that does each bullet
    public int damage = 3;
    public Rigidbody rb;

    //Add velotcity to the bullet. if doesn't collides is selfdestryed after 3 secs.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }

    // When collides, if has CharacterData changes the animation to Hit,
    // Calls the function Hit of the CaharacterAudio
    // And, because of i didn't understand very well the code, in which part damage the Target,
    // I have changed the CurrentHealth manually. CurrentHelath has get and set,
    // set was previously private, but I have changed it to public to make work this code.
    // In whichever case, the bullet is selfdestroyed after collides.
    void OnTriggerEnter(Collider collision)
    {
        CharacterData dataEnemy = collision.GetComponent<CharacterData>();
        if (dataEnemy != null)
        {
            Animator animEnemy = collision.GetComponentInChildren<Animator>();
            animEnemy.SetTrigger("Hit");
            CharacterAudio audioEnemy = collision.GetComponent<CharacterAudio>();
            audioEnemy.Hit(collision.transform.position);
            int vida = dataEnemy.Stats.CurrentHealth;
            dataEnemy.Stats.CurrentHealth = vida - damage;
        }
            Destroy(gameObject);
    }

}
