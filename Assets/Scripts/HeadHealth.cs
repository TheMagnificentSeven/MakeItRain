using UnityEngine;
using System.Collections;

public class HeadHealth : MonoBehaviour {

    private int health;
    private bool dead;
    private int lightDmg = 100;
    private int heavyDmg = 300;

	// Use this for initialization
	void Start () {
        health = 100;
        dead = false;
	}
	
	// Update is called once per frame

    void Update() {
        if (health <= 0 && !dead) {
            dead = true;
            // Game Over
            Debug.Log("Game Over!");
        }
    }

    void OnCollisionEnter(Collision collision) {
        GameObject rain = collision.gameObject;
        float v = rain.GetComponent<Rigidbody2D>().velocity.magnitude;

        if (rain.name == "dangerousObj")
        {
            takeDamage(heavyDmg*v);
        }
        else if (rain.name == "mediumObj")
        {
            takeDamage(lightDmg*v);
        }
        else if (rain.gameObject.name == "healObj")
        {
            healDamage(heavyDmg*v);
        }
    }

    void takeDamage(float damage)
    {
        health =- (int) damage;
        // Dan plays sound of pain
        Debug.Log(health);
    }

    void healDamage(float heal)
    {
        health =+ (int) heal;
        // Dan plays healing noise
    }
}
