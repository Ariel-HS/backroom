using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage; 
    PlayerHealth playerHealth;
    
    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        else if(collision.gameObject.tag == "WeakPoint")
        {
            playerHealth.WeakPoint(damage);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage*2);
        }
    }
}
