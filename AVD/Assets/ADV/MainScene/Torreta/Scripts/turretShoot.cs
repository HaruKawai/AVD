using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public float frequency = 1f;
    public Transform[] BulletPositions;
    public Animator[] GunsAnimators;
    public GameObject bulletPrefab;
    public AudioClip hitsound;
    public AudioClip explosion;
    public AudioClip transformer;
    public ParticleSystem particle;
    public int damage = 20;


    //When turret apears the sound transformer is played
    void Awake() 
    {
        GetComponent<AudioSource>().PlayOneShot(transformer);
    }

    //This is an event that is called at final of the first animation
    void Empezar() {
        StartCoroutine(Fire());
        StartCoroutine(Die());
    }



    //The coroutine used to change animation, play sond, instantiate a bullet and change the cannon.
    private int i = 0;
    IEnumerator Fire()
    {
        
        GunsAnimators[i].SetTrigger("Fire");
        Instantiate(bulletPrefab, BulletPositions[i].position, BulletPositions[i].rotation);
        GetComponent<AudioSource>().PlayOneShot(hitsound);
        i++;
        if (i >= BulletPositions.Length) i = 0;
        yield return new WaitForSeconds(1/frequency);

        StartCoroutine(Fire());
    }

    //Event to stop coroutines that is called at start of the last animation of the turret
    private void OnDisable() {
        StopAllCoroutines();    
    }

    //Coroutine to change the animation to Dead, play the explosion sound and particles.
    IEnumerator Die() 
    {
        yield return new WaitForSeconds(5);
        GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<AudioSource>().PlayOneShot(explosion);
        particle.Play();
    }

    // Event that is called to destroy the object at the final of the last animation of the turret
     void Die2ndTime() 
    {
        Destroy(gameObject);
    }
    

    //I also added this to Shoot as a Shootgun when the fire button is down.
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, BulletPositions[0].position, BulletPositions[0].rotation);
        Instantiate(bulletPrefab, BulletPositions[1].position, BulletPositions[1].rotation);
        Instantiate(bulletPrefab, BulletPositions[2].position, BulletPositions[2].rotation);
        Instantiate(bulletPrefab, BulletPositions[3].position, BulletPositions[3].rotation);
        GunsAnimators[0].SetTrigger("Fire");
        GunsAnimators[1].SetTrigger("Fire");
        GunsAnimators[2].SetTrigger("Fire");
        GunsAnimators[3].SetTrigger("Fire");
        GetComponent<AudioSource>().PlayOneShot(hitsound);
        GetComponent<AudioSource>().PlayOneShot(hitsound);
        GetComponent<AudioSource>().PlayOneShot(hitsound);
        GetComponent<AudioSource>().PlayOneShot(hitsound);

    }
}
