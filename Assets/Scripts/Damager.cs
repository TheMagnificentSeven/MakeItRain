using UnityEngine;
using System.Collections;

public class Damager : MonoBehaviour
{
    private HealthBar healthBar;

    // Use this for initialization
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject rain = collision.gameObject;
        if (rain.name.Contains("Left") || rain.name.Contains("Right") || rain.name.Equals("Floor"))
            return;
        float v = rain.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (v <= 5) v = 0;

        if (rain.name.Contains("Clone"))
        {
            bool torso = gameObject.name.Contains("torso");
            int damage = rain.GetComponent<RainDamage>().getDamage();
            Debug.Log(damage);
            if (damage < 0)
            {
                if (!torso)
                {
                    healthBar.healDamage(0 - (10 * damage));
                    Destroy(rain);
                }
            }
            else
            {
                float multiplier;
                if (torso)
                {
                    multiplier = 0.5f;
                    Debug.Log("Torso ouch!");
                }
                else
                    multiplier = 1.0f;
                healthBar.takeDamage(damage * v * multiplier);
            }
        }
    }
}