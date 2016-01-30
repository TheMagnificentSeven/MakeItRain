using UnityEngine;
using System.Collections;


public class RotateLeftArm : MonoBehaviour {
	public float speed = 1000f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.J))
            transform.Rotate(Vector3.back * speed);
        //transform.position += new Vector3 (0.0f, speed * Time.deltaTime,speed * Time.deltaTime);
    }
}
