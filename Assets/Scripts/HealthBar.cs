using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public GameObject healthBar;
	Health health;

	void Start() {
        healthBar = GameObject.Find("HealthBar/FullHealth");
		health = GameObject.Find ("head").GetComponent<Health> ();
	}

	void Update() {
		float myHealth = health.GetHealthRatio();
		//Debug.Log (myHealth);
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}


