using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointKeeper : MonoBehaviour
{
    int health;
    int coin;
    public PlayerHealth playerHealth;
    public ItemCollector itemCollector;
    static PointKeeper instance;
    LevelManager levelManager;

    void Awake()
    {
        ManageSingleton();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Start()
    {
        health = playerHealth.GetHealth();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ModifyHealth(int value)
    {
        health += value;
        if(health <= 0)
        {
            levelManager.GameOver();
        }
        Mathf.Clamp(health, 0, int.MaxValue);
    }

    public void ModifyCoin(int value)
    {
        coin += value;
        Mathf.Clamp(coin, 0, int.MaxValue);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetCoin()
    {
        return coin;
    }

    public void ResetHealth()
    {
        health = 10;
    }

    public void ResetCoin()
    {
        coin = 0;
    }
}
