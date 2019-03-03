using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] Collider collider;
    [SerializeField] int hitPoint;
    [SerializeField] ParticleSystem hitParticlePref;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] Transform particleParent;

	// Use this for initialization
	void Start () {
        collider = GetComponentInChildren<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoint < 1)
        {
            KillEnemy();
        }
        
    }

    void ProcessHit()
    {
        hitPoint -= 1;
        hitParticlePref.Play();
    }

    public void KillEnemy()
    {
        ParticleSystem vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        vfx.Play();
        float vfxDealy = vfx.main.duration;
        Destroy(vfx.gameObject, vfxDealy);
        Destroy(gameObject);
    }
}
