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
        if (health <= 0)
        {
            if (!dead)
            {
                dead = true;
                // stop player from moving
                // write Game Over to screen

            }
        }
    }

    void takeDamage(float damage)
    {
        health = -damage;
    }

}
