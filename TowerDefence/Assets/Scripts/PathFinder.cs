using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
    Dictionary<Vector2Int, WayPoint> grids = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();

    [SerializeField] bool isRunning = true;
    [SerializeField]WayPoint start;
    [SerializeField]WayPoint end;

    List<WayPoint> path = new List<WayPoint>();
    WayPoint currentNode;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.left,
        Vector2Int.right,
        Vector2Int.down
    };

    public List<WayPoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlock();
            MarkStartAndEnd();
            Search();
            FormPath();
        }
        
        return path;
    }

	void Update () {
 
	}

    void FormPath()
    {
        path.Add(end);
        end.isPlaceable = false;
        WayPoint previous = end.parent;
        while (previous != start)
        {
            previous.isPlaceable = false;
            path.Add(previous);  
            previous = previous.parent;                  
        }
        path.Add(start);
        start.isPlaceable = false;
        path.Reverse();
    }

    void Search()
    {
        queue.Enqueue(start);
        while(queue.Count > 0 && isRunning == true)
        {
            currentNode = queue.Dequeue();
            currentNode.visited = true;
            if(currentNode == end)
            {
                isRunning = false;
            }
            ExploreNeighbors();
        }
    }

    void LoadBlock()
    {
        var waypoints = FindObjectsOfType<WayPoint>();
        foreach(WayPoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPosition();
            if (grids.ContainsKey(gridPos) == true)
            {
                Debug.LogWarning("overlap " + waypoint);
            }
            else { 
                grids.Add(waypoint.GetGridPosition(), waypoint);
            }
        }
    }

    void MarkStartAndEnd()
    {
        start.SetTopColor(Color.blue);
        end.SetTopColor(Color.red);
    }

    void ExploreNeighbors()
    {
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborPos = currentNode.GetGridPosition() + direction;
            try
            {
                WayPoint neighbor = grids[neighborPos];
                if (neighbor.visited == false && queue.Contains(neighbor) == false)
                {
                    neighbor.parent = currentNode;
                    queue.Enqueue(neighbor);
                }
            }
            catch
            {
                //...
            }
        }
    }
}
