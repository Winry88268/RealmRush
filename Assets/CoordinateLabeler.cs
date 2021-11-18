using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake() 
    {
        this.label = this.GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
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
