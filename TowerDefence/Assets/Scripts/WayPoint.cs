using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {
    public bool visited = false;
    public bool isPlaceable = true;
    public WayPoint parent;

    [SerializeField] Color color;
    const int gridSize = 10;
    Vector2Int gridPosition;
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if (visited)
        {
            SetTopColor(color);
        }
    }

    public Vector2Int GetGridPosition()
    {
        gridPosition.x = Mathf.RoundToInt(transform.position.x / gridSize);
        gridPosition.y = Mathf.RoundToInt(transform.position.z / gridSize);
        return gridPosition;
    }

    public int getGridSize()
    {
        return gridSize; 
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topRenderer = transform.Find("top").GetComponent<MeshRenderer>();
        topRenderer.material.color = color;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isPlaceable == true)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print("can't");
            }
        }
       
    }
}
