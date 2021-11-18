using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject towerPrefab;

    void OnMouseDown() 
    {
        if(this.isPlaceable)
        {
            Instantiate(towerPrefab, this.transform.position, Quaternion.identity);
            this.isPlaceable = false;
        }   
    }
}
