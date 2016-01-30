﻿using UnityEngine;
using System.Collections;

public class RotateRightLeg : MonoBehaviour {
	public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.O)) {//right leg
			if(gameObject.transform.rotation.z> -0.1)
			transform.Rotate (Vector3.forward * Time.deltaTime * speed);
		}
	
	}
}
