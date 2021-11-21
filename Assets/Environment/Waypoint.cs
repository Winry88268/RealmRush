using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown() 
    {
        if(this.isPlaceable)
        {
            this.isPlaceable = !this.towerPrefab.CreateTower(this.towerPrefab, this.transform.position);
        }   
    }
}
