using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int coin = 0;
    PointKeeper pointKeeper;

    [SerializeField] private TextMeshProUGUI coinsText;

    void Awake()
    {
        pointKeeper = FindObjectOfType<PointKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            pointKeeper.ModifyCoin(1);
        }
    }

    public int GetCoin()
    {
        return coin;
    }
}
