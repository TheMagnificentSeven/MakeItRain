using UnityEngine;
using System.Collections;

public class XRotate : MonoBehaviour
{

    [SerializeField]
    public float speed;
    [SerializeField]
    public KeyCode key;

    [SerializeField]
    public int minAngle;
    [SerializeField]
    public int maxAngle;
    [SerializeField]
    public bool clockwise = true;

    private HingeJoint2D hinge;
    private JointMotor2D motor;

	// It is at 90 degrees during rest position, and decreases as arm moves up
	private float jointAngle; 

    // Use this for initialization
    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        motor = hinge.motor;
		jointAngle = hinge.jointAngle;
    }

    // Update is called once per frame
    void Update()
    {
        jointAngle = hinge.jointAngle;

        if (clockwise)
        {
            if (Input.GetKey(key)) {
                if (jointAngle < maxAngle)
                    motor.motorSpeed = speed;
                else
                    motor.motorSpeed = 0;
            } else {
                if (jointAngle > minAngle)
                    motor.motorSpeed = -speed;
                else
                    motor.motorSpeed = 0;
            }
        } else
        {
            if (Input.GetKey(key))
            {
                if (jointAngle > minAngle)
                    motor.motorSpeed = -speed;
                else
                    motor.motorSpeed = 0;
            }
            else {
                if (jointAngle < maxAngle)
                    motor.motorSpeed = speed;
                else
                    motor.motorSpeed = 0;
            }
        }

        hinge.motor = motor;
    }

	public float getJointAngle() {
		return jointAngle;
	}
}
