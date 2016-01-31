using UnityEngine;
using UnityEngine.UI; //new
using System.Collections;

public class PoseDetection : MonoBehaviour {
	Launch launchHandler;
	float threshold = 20;

	public Text scoreText; 
	public Text timerText; 
	float timeLeft = 31; //ALTHOUGH 31 HERE, COUNT WILL START AT 30 

	private int score;
	private int correctCount; 

	// Use this for initialization
	void Start () {
		launchHandler = GameObject.Find ("BackgroundImage").GetComponent<Launch> ();
		score = 0;  
		UpdateScore(); 

		correctCount = 0; 
	}
	
	// Update is called once per frame
	void Update () {

		// TODO: Retrieve the randomized pose from GenerateMove
		Pose expectedPose = launchHandler.GetPose()[1];

		XRotate leftArm = GameObject.Find ("leftArm").GetComponent<XRotate> ();
		XRotate rightArm = GameObject.Find ("rightArm").GetComponent<XRotate> ();
		XRotate leftLeg = GameObject.Find ("leftLeg").GetComponent<XRotate> ();
		XRotate rightLeg = GameObject.Find ("rightLeg").GetComponent<XRotate> ();

		timeLeft -= Time.deltaTime;

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

			score = score + 1; 
			UpdateScore(); 
			correctCount = correctCount + 1; 
            GameObject.Find("BackgroundImage").GetComponent<MakeItRain>().Rain();
		}

		UpdateTime (); //NEW
	
	}

	void UpdateScore(){ 
		scoreText.text = "SCORE : " + score.ToString();
	}

	void UpdateTime(){ 
		if (timeLeft > 0) {
			timerText.text = "TIMER : " + ((int)timeLeft).ToString ();
		} else {
			timerText.text = "TIMER : 0";
		}

		if (correctCount == 3) {
		//TO DO: if all 3 posts correct, then do sth.
		}
	}
}
