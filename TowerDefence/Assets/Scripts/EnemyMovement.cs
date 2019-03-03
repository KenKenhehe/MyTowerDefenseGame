using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] List<WayPoint> path;
    [SerializeField] float movePeriod;
    [SerializeField] ParticleSystem goalFX;
    PathFinder PathFinder;

	// Use this for initialization
	void Start () {
        PathFinder = GetComponentInParent<PathFinder>();
        path = PathFinder.GetPath();
        StartCoroutine(FollowPath());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FollowPath()
    {
        foreach (WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(movePeriod);
        }
        SelfDestruct();
    }

    void SelfDestruct()
    {
        ParticleSystem vfx = Instantiate(goalFX, transform.position, Quaternion.identity);
        vfx.Play();
        float vfxDealy = vfx.main.duration;
        Destroy(vfx.gameObject, vfxDealy);
        Destroy(gameObject);
    }
}
