using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    ///[SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI coinText;
    PointKeeper pointKeeper;

    public Slider healthSlider;

    void Awake()
    {
        pointKeeper = FindObjectOfType<PointKeeper>();
    }

    void Start()
    {
        ///healthText.text = "Health: " + pointKeeper.GetHealth();
        healthSlider.maxValue = pointKeeper.GetHealth();
        healthSlider.value = pointKeeper.GetHealth();
        coinText.text = "Coins: " + pointKeeper.GetCoin();
    }

    void Update()
    {
        ///healthText.text = "Health: " + pointKeeper.GetHealth();
        healthSlider.value = pointKeeper.GetHealth();
        coinText.text = "Coins: " + pointKeeper.GetCoin();
    }
}
