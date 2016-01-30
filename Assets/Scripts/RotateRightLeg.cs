using UnityEngine;
using System.Collections;

public class RotateRightLeg : MonoBehaviour {
	public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.O)) {//right leg
			Debug.Log (gameObject.transform.rotation.z);
			transform.Rotate (Vector3.forward * Time.deltaTime * speed);
		}
	
	}
}
