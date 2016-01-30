﻿using UnityEngine;
using System.Collections;


public class Rotate : MonoBehaviour {
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.J)) { //left arm
			if(gameObject.transform.rotation.z* Time.deltaTime * speed <8.1)
				transform.Rotate (Vector3.back * Time.deltaTime * speed);
		}
	}
}
