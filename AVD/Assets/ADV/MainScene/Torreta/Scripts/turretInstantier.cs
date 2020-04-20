using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretInstantier : MonoBehaviour
{
    public GameObject torretaPrefab;
    public float speed = 5f;
    public int damage = 10;
    private Rigidbody rb;

    // To start add force to the ball and is destroyed if doesn't collides with nothing
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }

    // If collides with ground we look for another turret, destroy all turrets that already exists
    // instantiate a turret in the position of the collision and destroy the ball
    // if the ball doesnt collides with ground is also destroyed
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            GameObject[] torretes = GameObject.FindGameObjectsWithTag("torreta");
            foreach (GameObject torreta in torretes)
            {
                torreta.GetComponent<Animator>().SetTrigger("Dead");
                torreta.GetComponent<AudioSource>().PlayOneShot(torreta.GetComponent<turretShoot>().explosion);
                torreta.GetComponent<turretShoot>().particle.Play();
            }
            Instantiate(torretaPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
        else { Destroy(gameObject); }
    }
}
