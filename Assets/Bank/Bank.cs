using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        currBalance -= Mathf.Abs(amount);
    }
}
