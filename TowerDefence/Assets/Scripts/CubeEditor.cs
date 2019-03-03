using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[ExecuteInEditMode]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour {

    TextMesh textMesh;
    //Vector3 gridPosition;
    WayPoint wayPoint;

    void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
    }

    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    void Update () {
        SnapToGridPosition();
        //UpdateLabel();
    }

    void UpdateLabel()
    {
        string blockLabel = wayPoint.GetGridPosition().x +
            "," + 
            wayPoint.GetGridPosition().y;
        textMesh.text = blockLabel;
        this.gameObject.name = blockLabel;
    }

    void SnapToGridPosition()
    {
        int gridSize = wayPoint.getGridSize();
        
        transform.position = new Vector3(
            wayPoint.GetGridPosition().x * gridSize, 
            0,
            wayPoint.GetGridPosition().y * gridSize);
    }
}
