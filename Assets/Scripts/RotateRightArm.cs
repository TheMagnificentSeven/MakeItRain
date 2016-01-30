using UnityEngine;
using System.Collections;

public class RotateRightArm : MonoBehaviour {

	public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.P)) { //right arm
			if(gameObject.transform.rotation.z > -0.4)
			transform.Rotate (Vector3.forward * Time.deltaTime * speed);
		}
	}
}
