using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [Tooltip("Match for UnityEditor snap Settings")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }

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

    public void BlockNode(Vector2Int coordinates)
    {
        if(this.grid.ContainsKey(coordinates))
        {
            this.grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();

        coordinates.x = Mathf.RoundToInt(position.x / this.unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / this.unityGridSize);

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();

        position.x = coordinates.x * this.unityGridSize;
        position.z = coordinates.y * this.unityGridSize;

        return position;
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
