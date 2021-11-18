using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.red;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake() 
    {
        this.label = this.GetComponent<TextMeshPro>();
        this.label.enabled = false;
        this.waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            this.label.enabled = !this.label.IsActive();
        }
    }

    void ColorCoordinates()
    {
        if(waypoint.IsPlaceable)
        {
            this.label.color = defaultColor;
        }
        else
        {
            this.label.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        this.coordinates.x = Mathf.RoundToInt(this.transform.position.x / UnityEditor.EditorSnapSettings.move.x);
        this.coordinates.y = Mathf.RoundToInt(this.transform.position.z / UnityEditor.EditorSnapSettings.move.z);

        this.label.text = this.coordinates.x + "," + this.coordinates.y;
    }

    void UpdateObjectName()
    {
        this.transform.parent.name = this.coordinates.ToString();
    }
}
