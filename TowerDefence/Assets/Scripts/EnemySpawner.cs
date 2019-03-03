using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] float secondsBetweenSpawn;
    float spawnTime;
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] Transform enemyParent;
    [SerializeField] Text enemyCountText;
    [SerializeField] int enemyCount = 0;
    
	// Use this for initialization
	void Start () {
        enemyCountText.text = "Enemy: " + enemyCount; 
        StartCoroutine(SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            enemyCount++;
            enemyCountText.text = "Enemy: " + enemyCount;
            GameObject enemyInstance = Instantiate(enemyToSpawn, gameObject.transform.parent);
            enemyInstance.transform.parent = enemyParent;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
