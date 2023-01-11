using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    PointKeeper pointKeeper;

    void Awake()
    {
        pointKeeper = FindObjectOfType<PointKeeper>();
    }

    void Start()
    {
        scoreText.text = "Your Score: " + pointKeeper.GetCoin();
    }
}
