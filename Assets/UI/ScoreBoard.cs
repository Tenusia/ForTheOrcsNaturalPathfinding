using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;
    Bank bank;

    void Start() 
    {
        bank = FindObjectOfType<Bank>();
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Gold: 000";    
    }

    void Update()
    {
        scoreText.text = bank.CurrentBalance.ToString();
    }
}
