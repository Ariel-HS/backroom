using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI coinText;
    PointKeeper pointKeeper;

    void Awake()
    {
        pointKeeper = FindObjectOfType<PointKeeper>();
    }

    void Start()
    {
        healthText.text = "Health: " + pointKeeper.GetHealth();
        coinText.text = "Coins: " + pointKeeper.GetCoin();
    }

    void Update()
    {
        healthText.text = "Health: " + pointKeeper.GetHealth();
        coinText.text = "Coins: " + pointKeeper.GetCoin();
    }
}
