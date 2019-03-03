using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] int health;
    [SerializeField] Text healthText;
	// Use this for initialization
	void Start () {
        healthText.text = "Health: " + health.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        health -= 1;
        healthText.text = "Health: " + health.ToString();
    }
}
