using UnityEngine;
using System.Collections;


public class RotateLeftArm : MonoBehaviour {
	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetKey (KeyCode.J))
			transform.position += new Vector3 (0.0f, speed * Time.deltaTime,speed * Time.deltaTime);
	}
}
