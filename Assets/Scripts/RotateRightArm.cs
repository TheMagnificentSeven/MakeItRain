using UnityEngine;
using System.Collections;

public class RotateRightArm : MonoBehaviour {
	public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.L))
			transform.position += new Vector3 (0.0f, speed * Time.deltaTime,0.0f);

	}
}
