using UnityEngine;
using System.Collections;

public class HeadHealth : MonoBehaviour
{

    private int health = MAX_HEALTH;
    private bool dead;
    private int lightDmg = 1;
    private int heavyDmg = 3;
    private static int MAX_HEALTH = 300;
    private AudioSource[] grunts;

    // Use this for initialization
    void Start()
    {
        grunts = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Debug.Log("game over!!");
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject rain = collision.gameObject;
        if (rain.name.Equals("LeftWall") || rain.name.Equals("RightWall") || rain.name.Equals("Floor"))
            return;
        float v = rain.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (v <= 5) v = 0;

        if (rain.name.Contains("Clone"))
        {
            Debug.Log(health);
            int damage = rain.GetComponent<RainWatcher>().getDamage();
            Debug.Log(damage);
            if (damage < 0)
            {
                healDamage(0 - (damage));
                Destroy(rain);
            }
            else
                takeDamage(damage*v);
        }
    }

    void takeDamage(float damage)
    {
        health -= (int)damage;
        if (damage <= 10)
            grunts[1].Play();
        else
            grunts[0].Play();
        if (health <= 0 && !dead)
            dead = true;
    }

    void healDamage(float heal)
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