using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] TextMeshProUGUI displayBalance;
    
    int currBalance;
    public int CurrBalance { get { return currBalance; } }

    void Awake() 
    {
        this.currBalance = this.startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        this.currBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        this.currBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        
        if(currBalance < 0)
        {
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        this.displayBalance.text = this.currBalance.ToString();
    }

    void ReloadScene()
    {
        Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.buildIndex);
    }
}
