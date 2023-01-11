using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    public int damage;

    void OnCollisionEnter2D(Collision2D Collision)
    {
        if(Collision.gameObject.tag == "Enemy")
        {
            Collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        else
        {
            PlayHitEffect();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
