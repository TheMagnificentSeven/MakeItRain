using UnityEngine;
using System.Collections;

public class RotateLeftLeg : MonoBehaviour {
	public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.S))//left leg
			transform.Rotate (Vector3.back * Time.deltaTime * speed);
	}
}
