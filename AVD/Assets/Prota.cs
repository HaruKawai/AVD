using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prota : MonoBehaviour
{
    public int health = 100;
    public HealthBar healthBar;
    public GameObject deathEffect;
    
    public void TakeDamage (int damage)
    {
        gameObject.GetComponent<Player2DControll>().damaged = true;
        health -= damage;
        healthBar.SetSize(health);
        if(health <=0) {
            Die();
        }
    }
    void Die() 
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
