using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    
    [SerializeField] Vector2Int startCoords;
    public Vector2Int StartCoords { get { return startCoords; } }

    [SerializeField] Vector2Int endCoords;
    public Vector2Int EndCoords { get { return endCoords; } }

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    Node startNode, endNode, currSearchNode;

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
            this.startNode = this.grid[startCoords];
            this.endNode = this.grid[endCoords];
        }
    }    

    void Start() 
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        this.gridManager.ResetNodes();
        BreadthFirstSearch();
        return BuildPath();
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
                neighbor.connectedTo = this.currSearchNode;
                this.reached.Add(neighbor.coordinates, neighbor);
                this.frontier.Enqueue(neighbor);
            }
        }
    }

    void BreadthFirstSearch()
    {
        this.startNode.isWalkable = true;
        this.endNode.isWalkable = true;

        this.frontier.Clear();
        this.reached.Clear();

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

    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currNode = this.endNode;

        path.Add(currNode);
        currNode.isPath = true;

        while(currNode.connectedTo != null)
        {
            currNode = currNode.connectedTo;
            path.Add(currNode);
            currNode.isPath = true;
        }

        path.Reverse();

        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if(this.grid.ContainsKey(coordinates))
        {
            bool previousState = this.grid[coordinates].isWalkable;

            this.grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath();
            this.grid[coordinates].isWalkable = previousState;

            if(newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }

        return false;
    }
}
