using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] TextMeshProUGUI changeBalance;
    [SerializeField] float waitLength = 2f;
    [SerializeField] int scoreGoal = 500;

    public int CurrentBalance { get { return currentBalance; }}

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
        ShowScoreChange(false);
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        StartCoroutine(ShowChangedAmount("+" + amount));
        UpdateDisplay();

        //ADD KILL OR GOLD SCORE COUNTER FOR WIN CONDITION (can create multiple waves with stronger enemies)
        if(currentBalance >= scoreGoal)
        {
            //ADD win screen, go to next wave/scene
            ReloadScene();
        }
    }
    
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        StartCoroutine(ShowChangedAmount("-" + amount));
        UpdateDisplay();

        if(currentBalance < 0)
        {
            //Lose the game -> GAME OVER SCREEN
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    IEnumerator ShowChangedAmount(string amount)
    {
        ShowScoreChange(true);
        changeBalance.text = amount;
        yield return new WaitForSeconds(waitLength);
        ShowScoreChange(false);
    }

    void ShowScoreChange(bool IsShown)
    {
        changeBalance.enabled = IsShown;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
