using UnityEngine;
using System.Collections;

public class DanHealth : MonoBehaviour {

    public float health;
    private bool dead;

	// Use this for initialization
	void Start () {
        health = 100f;

	}
	
	// Update is called once per frame

    void Update()
    {

    }

	void takeDamage (float damage) {
        if (health <= 0)
        {
            if (!dead)
                dead = true;
        }
        else
            health =- damage;
	}
}
