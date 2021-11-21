using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    
    int currBalance;
    public int CurrBalance { get { return currBalance; } }

    void Awake() 
    {
        currBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        if(currBalance > amount)
        {
            currBalance -= Mathf.Abs(amount);
        }
        
        if(currBalance < 0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.buildIndex);
    }
}
