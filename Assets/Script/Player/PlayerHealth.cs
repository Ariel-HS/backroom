using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{ 
    [SerializeField] bool isPlayer;
    [SerializeField] bool applyCameraShake;
    LevelManager levelManager;
    CameraShake cameraShake;
    PointKeeper pointKeeper;
    [SerializeField] int health = 10;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        pointKeeper = FindObjectOfType<PointKeeper>();
    }

    public void TakeDamage(int damage)
    {
        ShakeCamera();
        pointKeeper.ModifyHealth(-damage);
    }

    public void Heal(int value)
    {
        pointKeeper.ModifyHealth(value);
    }

    public void WeakPoint(int damage)
    {
        pointKeeper.ModifyHealth(-damage);
    }

    public void Die()
    {
        if(isPlayer)
        {
            levelManager.GameOver();
        }
        Destroy(gameObject);
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    public int GetHealth()
    {
        return health;
    }
}