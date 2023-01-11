using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] [Range(0f, 1f)] float hitVolume = 1f;
    public int maxHealth = 10; 
    public int health;
    public int healPoint;
    public PlayerHealth playerHealth;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage; 
        PlayHitEffect();
        PlayHitSFX();
        if(health <= 0)
        {
            Destroy(gameObject);
            playerHealth.Heal(healPoint);
        }
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void PlayHitSFX()
    {
        AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position, hitVolume);
    }
}
