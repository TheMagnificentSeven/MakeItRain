using UnityEngine;
using UnityEngine.UI; //new
using System.Collections;

public class PoseDetection : MonoBehaviour {
	Launch launchHandler;
	float threshold = 20;

	public Text scoreText; // new
	private int count; //new


	// Use this for initialization
	void Start () {
		launchHandler = GameObject.Find ("BackgroundImage").GetComponent<Launch> ();
		count = 0; //new
		UpdateScore(); //new

	}
	
	// Update is called once per frame
	void Update () {

		// TODO: Retrieve the randomized pose from GenerateMove
		Pose expectedPose = launchHandler.GetPose()[1];

		XRotate leftArm = GameObject.Find ("leftArm").GetComponent<XRotate> ();
		XRotate rightArm = GameObject.Find ("rightArm").GetComponent<XRotate> ();
		XRotate leftLeg = GameObject.Find ("leftLeg").GetComponent<XRotate> ();
		XRotate rightLeg = GameObject.Find ("rightLeg").GetComponent<XRotate> ();

		if ((leftArm.getJointAngle() <= expectedPose.getLeftArm() + threshold 
			&& leftArm.getJointAngle() >= expectedPose.getLeftArm() - threshold)
			&& (leftLeg.getJointAngle() <= expectedPose.getLeftLeg() + threshold 
				&& leftLeg.getJointAngle() >= expectedPose.getLeftLeg() - threshold)
			&& (rightArm.getJointAngle() <= expectedPose.getRightArm() + threshold 
				&& rightArm.getJointAngle() >= expectedPose.getRightArm() - threshold)
			&& (rightLeg.getJointAngle() <= expectedPose.getRightLeg() + threshold 
				&& rightLeg.getJointAngle() >= expectedPose.getRightLeg() - threshold)){
			// Yay you got the pose!
			Debug.Log("Yay you got the pose!");
			count = count + 1; //new
			UpdateScore();     //new
            GameObject.Find("BackgroundImage").GetComponent<MakeItRain>().Rain();
            GameObject.Find("DancingLightsSpawner").GetComponent<ParticleSpawner>().spawnParticles();
        }
	}

	void UpdateScore(){ //new
		scoreText.text = "SCORE : " + count.ToString();
	}
}
