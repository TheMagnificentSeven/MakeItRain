using UnityEngine;
using System.Collections;

public class XRotate : MonoBehaviour {

    [SerializeField] public float speed;
    [SerializeField]
    public KeyCode key;

    private HingeJoint2D hinge;
    private JointMotor2D motor;

    // Use this for initialization
    void Start () {
        hinge = GetComponent<HingeJoint2D>();
        motor = hinge.motor;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(key))
        {
            motor.motorSpeed = speed;
        }
        else
        {
            motor.motorSpeed = -speed;
        }


        hinge.motor = motor;
    }
}
