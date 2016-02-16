using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public GameObject healthBar;
	HeadHealth headHealth;

	void Start() {
        healthBar = GameObject.Find("HealthBar/FullHealth");
		headHealth = GameObject.Find ("head").GetComponent<Health> ();
	}

	void Update() {
		float myHealth = headHealth.GetHealthRatio();
		//Debug.Log (myHealth);
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}


