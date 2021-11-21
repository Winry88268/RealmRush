using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    void Awake() 
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if(this.grid.ContainsKey(coordinates))
        {
            return this.grid[coordinates];
        }
        
        return null;
    }

    void CreateGrid()
    {
        for(int x = 0; x < this.gridSize.x; x++)
        {
            for(int y = 0; y < this.gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x,y);
                this.grid.Add(coordinates, new Node(coordinates,true));
            }
        }
    }
}
