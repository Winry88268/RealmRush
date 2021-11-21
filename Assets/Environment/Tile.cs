using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    void Awake() 
    {
        this.gridManager = FindObjectOfType<GridManager>();
    }

    void Start() 
    {
        if(this.gridManager != null)
        {
            this.coordinates = this.gridManager.GetCoordinatesFromPosition(this.transform.position);

            if(!isPlaceable)
            {
                this.gridManager.BlockNode(this.coordinates);
            }
        }
    }

    void OnMouseDown() 
    {
        if(this.isPlaceable)
        {
            this.isPlaceable = !this.towerPrefab.CreateTower(this.towerPrefab, this.transform.position);
        }   
    }
}
