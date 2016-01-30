using UnityEngine;
using System.Collections;

public class ButtomInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.I))
			transform.Rotate (Vector3.forward);
		if (Input.GetKey (KeyCode.K))
			transform.Rotate (Vector3.back);
	}
}
