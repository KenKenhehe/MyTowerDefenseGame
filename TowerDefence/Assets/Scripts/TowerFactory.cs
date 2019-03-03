using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [SerializeField] TowerHandler towerPref;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform parent;
    int count = 0;
    Queue<TowerHandler> towerQueue = new Queue<TowerHandler>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void AddTower(WayPoint baseWaypoint)
    {
        count = towerQueue.Count;
        if(count < towerLimit)
        {
            InstantiateTower(baseWaypoint);
            print(towerQueue.Count);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
            print(towerQueue.Count);
        }
    }

    void InstantiateTower(WayPoint baseWaypoint)
    {
        TowerHandler newTower = Instantiate(towerPref, baseWaypoint.gameObject.transform.position, Quaternion.identity);
        newTower.transform.parent = parent;
        towerQueue.Enqueue(newTower);
        baseWaypoint.isPlaceable = false;
        newTower.baseWaypoint = baseWaypoint;
    }

    void MoveExistingTower(WayPoint newBaseWaypoint)
    {
        TowerHandler oldTower = towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;

        newBaseWaypoint.isPlaceable = false;
        oldTower.baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position;
        towerQueue.Enqueue(oldTower);
    }
}
