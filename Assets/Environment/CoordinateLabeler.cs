using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.red;
    [SerializeField] Color exploredColor = Color.grey;
    [SerializeField] Color pathColor = Color.yellow;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    void Awake() 
    {
        this.label = this.GetComponent<TextMeshPro>();
        this.label.enabled = false;
        this.gridManager = FindObjectOfType<GridManager>();

        DisplayCoordinates();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            this.label.enabled = !this.label.IsActive();
        }
    }

    void SetLabelColor()
    {
        if(this.gridManager == null) { return; }

        Node node = this.gridManager.GetNode(this.coordinates);

        if(node == null) { return; }

        if(!node.isWalkable)
        {
            this.label.color = this.blockedColor;
        }
        else if(node.isPath)
        {
            this.label.color = this.pathColor;
        }
        else if(node.isExplored)
        {
            this.label.color = this.exploredColor;
        }
        else
        {
            this.label.color = this.defaultColor;
        }
    }

    void DisplayCoordinates()
    {
        if(this.gridManager == null) { return; }

        this.coordinates.x = Mathf.RoundToInt(this.transform.position.x / this.gridManager.UnityGridSize);
        this.coordinates.y = Mathf.RoundToInt(this.transform.position.z / this.gridManager.UnityGridSize);

        this.label.text = this.coordinates.x + "," + this.coordinates.y;
    }

    void UpdateObjectName()
    {
        this.transform.parent.name = this.coordinates.ToString();
    }
}
