using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private GameObject healthBar;
    private int deadTimer;
    public int health;
    public static int MAX_HEALTH = 300;
    private AudioSource[] grunts;

    void Start() {
        healthBar = GameObject.Find("HealthBar/FullHealth");
        grunts = GetComponents<AudioSource>();
        deadTimer = 0;
        health = MAX_HEALTH;
	}

	void Update() {

        float myHealth = GetHealthRatio();
		//Debug.Log (myHealth);
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        // dead Dan
        if (health <= 0)
        {
            Debug.Log("game over; count to 10");
            deadTimer++;
            if (deadTimer >= 10)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
                grunts[0].Play();
            }
        }
    }

    public void takeDamage(float damage)
    {
        if (health >= 0)
        {
            health -= (int)damage;
            if (damage > 0)
            {
                if (damage <= 10)
                    grunts[1].Play();
                else
                    grunts[0].Play();
            }
        }
    }

    public void healDamage(float heal)
    {
        health += (int)heal;
        if (health > MAX_HEALTH)
            health = MAX_HEALTH;
        // Dan plays healing noise
    }

    public float GetHealthRatio()
    {
        return (float)(health) / (float)MAX_HEALTH;
    }
}


