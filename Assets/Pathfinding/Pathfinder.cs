using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Node startNode, endNode, currSearchNode;
    [SerializeField] Vector2Int startCoords;
    [SerializeField] Vector2Int endCoords;
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>(); 
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    GridManager gridManager;

    void Awake() 
    {
        this.gridManager = FindObjectOfType<GridManager>();

        if(this.gridManager != null)
        {
            this.grid = this.gridManager.Grid;
        }

        this.startNode = new Node(startCoords, true);
        this.endNode = new Node(endCoords, true);
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

        foreach(Node neighbor in neighbors)
        {
            if(!this.reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                this.reached.Add(neighbor.coordinates, neighbor);
                this.frontier.Enqueue(neighbor);
            }
        }
    }

    void BreadthFirstSearch()
    {
        bool isRunning = true;

        this.frontier.Enqueue(startNode);
        this.reached.Add(startCoords, startNode);

        while(this.frontier.Count > 0 && isRunning)
        {
            this.currSearchNode = this.frontier.Dequeue();
            this.currSearchNode.isExplored = true;
            ExploreNeighbors();
            if(this.currSearchNode.coordinates == endCoords)
            {
                isRunning = false;
            }
        }
    }
}
