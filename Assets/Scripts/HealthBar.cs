using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public GameObject healthBar;
	HeadHealth headHealth;

	void Start() {
		headHealth = GameObject.Find ("head").GetComponent<HeadHealth> ();
	}

	void Update() {
		float myHealth = headHealth.GetHealthRatio();
		//Debug.Log (myHealth);
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}


