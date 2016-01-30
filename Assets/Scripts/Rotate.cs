using UnityEngine;
using System.Collections;


public class Rotate : MonoBehaviour {
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.J)) {
			if(gameObject.transform.rotation.z* Time.deltaTime * speed <8.1)
				transform.Rotate (Vector3.back * Time.deltaTime * speed);
		}
			/*if (Input.GetKey (KeyCode.L))
			transform.Rotate (Vector3.forward *speed);
		if (Input.GetKey (KeyCode.F))
			transform.position += new Vector3 (0.0f,0.0f,speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.S))
			transform.position += new Vector3 (0.0f, 0.0f,speed * Time.deltaTime);*/
	}
}
