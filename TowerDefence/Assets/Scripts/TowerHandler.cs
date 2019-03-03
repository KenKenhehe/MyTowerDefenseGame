using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHandler : MonoBehaviour {
    [SerializeField] Transform towerToMove;
    [SerializeField] float attackRange;
    [SerializeField] ParticleSystem projectile;

    public WayPoint baseWaypoint;//what the tower standing on
    Transform targetEnemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetTargetEnemy();
        towerToMove.LookAt(targetEnemy);
        FireAtEnemy();   
	}

    void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0)
        {
            return; 
        }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(EnemyDamage enemy in sceneEnemies)
        {
            closestEnemy = getClosest(closestEnemy, enemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    Transform getClosest(Transform t1, Transform t2)
    {
        float tOneToTower = Vector3.Distance(t1.position, transform.position);
        float tTwoToTower = Vector3.Distance(t2.position, transform.position);
        if (tOneToTower < tTwoToTower)
        {
            return t1;
        }
        return t2;
    }

    void FireAtEnemy()
    {
        if (targetEnemy != null)
        {
            float distanceToEnemy = Vector3.Distance(gameObject.transform.position, targetEnemy.transform.position);
            if (distanceToEnemy < attackRange)
            {
                Shoot(true);
            }
            else
            {
                Shoot(false);
            }
        }
        else
        {
            Shoot(false);
        }
        }

    void Shoot(bool isActive)
    {
        var particleEmitter = projectile.emission;
        particleEmitter.enabled = isActive;
    }

    
}
