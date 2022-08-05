using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int startMoney = 250;
    public int startLives = 3;

    public static int Money;
    public static int Lives;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI livesText;

    void Start() 
    {
        Money = startMoney;
        Lives = startLives;
    }

    void Update() 
    {
        moneyText.text = "$" + Money;
        livesText.text = Lives + " LIVES";

        if(Lives <= 0) {
            Debug.Log("Game Over!");
        }
    }
}
