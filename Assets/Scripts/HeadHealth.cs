using UnityEngine;
using System.Collections;

public class HeadHealth : MonoBehaviour {

	private int health = MAX_HEALTH;
    private bool dead;
    private int lightDmg = 1;
    private int heavyDmg = 3;
	private static int MAX_HEALTH = 100;
    private AudioSource[] grunts;

	// Use this for initialization
	void Start () {
        grunts = gameObject.GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject rain = collision.gameObject;
        if (rain.name.Equals("LeftWall") || rain.name.Equals("RightWall") || rain.name.Equals("Floor"))
            return;
        float v = rain.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (v <= 5) v = 0;
        if (rain.name == "healObj(Clone)")
        {
            healDamage(lightDmg);
            Destroy(rain);
        }
        else
        {
            if (rain.name == "dangerousObj(Clone)")
            {
                takeDamage(heavyDmg * v);
                grunts[0].Play();
            }
                
            else if (rain.name == "mediumObj(Clone)")
            {
                takeDamage(lightDmg * v);
                grunts[1].Play();
            }
                
        }
    }

    void takeDamage(float damage)
    {
        health -= (int)damage;
        // Dan plays sound of pain
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
		if (health > MAX_HEALTH)
			health = MAX_HEALTH;
        // Dan plays healing noise
    }

	public float GetHealthRatio() {
		return (float)(health) / (float)MAX_HEALTH;
	}
}
