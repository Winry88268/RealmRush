using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currSearchNode;
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

    void Awake() 
    {
        this.gridManager = FindObjectOfType<GridManager>();

        if(this.gridManager != null)
        {
            this.grid = this.gridManager.Grid;
        }
    }    

    void Start() 
    {
        ExploreNeighbors();
    }

    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach(Vector2Int direction in this.directions)
        {
            Vector2Int neighborCoords = this.currSearchNode.coordinates + direction;

            if(this.grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(this.grid[neighborCoords]);
            }
        }
    }
}
