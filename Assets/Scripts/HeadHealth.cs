using UnityEngine;
using System.Collections;

public class HeadHealth : MonoBehaviour {

    private int health = 500;
    private bool dead;
    private int lightDmg = 1;
    private int heavyDmg = 3;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject rain = collision.gameObject;
        if (rain.name.Equals("LeftWall") || rain.name.Equals("RightWall"))
        {
            float v = rain.GetComponent<Rigidbody2D>().velocity.magnitude;
            if (v <= 10) v = 0;
        }
        if (rain.name == "healObj(Clone)")
        {
            healDamage(heavyDmg*v);
            Destroy(rain);
        }
        else
        {
            if (rain.name == "dangerousObj(Clone)")
                takeDamage(heavyDmg * v);
            else if (rain.name == "mediumObj(Clone)")
                takeDamage(lightDmg * v);
        }
    }

    void takeDamage(float damage)
    {
        health -= (int)damage;
        // Dan plays sound of pain
        Debug.Log(health);
        if (health <= 0 && !dead)
        {
            dead = true;
            Debug.Log("game over!!");
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }

    void healDamage(float heal)
    {
        health += (int) heal;
        // Dan plays healing noise
    }
}
