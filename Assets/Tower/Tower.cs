using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 75;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null) { return false; }

        if(bank.CurrBalance >= this.towerCost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity); 
            bank.Withdraw(this.towerCost);
            return true;
        }
        
        return false;
    }
}
