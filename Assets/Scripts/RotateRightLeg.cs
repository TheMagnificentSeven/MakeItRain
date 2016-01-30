using UnityEngine;
using System.Collections;

public class RotateRightLeg : MonoBehaviour {
	public float speed = 2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.F))
			transform.position += new Vector3 (0.0f,0.0f,speed * Time.deltaTime);
	}
}
