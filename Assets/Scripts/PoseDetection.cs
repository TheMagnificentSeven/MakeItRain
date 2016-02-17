using UnityEngine;
using System.Collections.Generic;

public class PoseDetection : MonoBehaviour {
	Launch launchHandler;
	float threshold = 20;
	int poseArrayCounter;
	GenerateMove generateMove;
	List<Pose> listOfGenPose;
	private int correctCount; 
	const float yArrow = 1.25f;

	// Use this for initialization
	void Start () {
		launchHandler = GameObject.Find ("BackgroundImage").GetComponent<Launch> ();
		generateMove = GameObject.Find ("BackgroundImage").GetComponent<GenerateMove> ();
		poseArrayCounter = -1; // Indicating it hasn't generated new poses yet
	}
	
	// Update is called once per frame
	void Update () {
		
		// Retrive the current pose from the list of generated poses
		if (poseArrayCounter == -1) {
			//Debug.Log ("Generating...");
			generateMove.Generate ();
			listOfGenPose = generateMove.GetGeneratedPoseList ();
			poseArrayCounter = 0;
			setArrow (poseArrayCounter);
		}

		Pose expectedPose = listOfGenPose[poseArrayCounter];

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
                && rightLeg.getJointAngle() >= expectedPose.getRightLeg() - threshold))
        {
            // Yay you got the pose!

            // Celebratory sparkles
            GameObject.Find("DancingLightsSpawner").GetComponent<ParticleSpawner>().spawnParticles();

            // We've finished all the poses, make it rain!
			if (++poseArrayCounter == generateMove.GetTotalPoses())
            {
                GameObject.Find("BigDancingLightsSpawner").GetComponent<ParticleSpawner>().spawnParticles();
                GameObject.Find("BackgroundImage").GetComponent<MakeItRain>().Rain();
				poseArrayCounter = -1;
				return;
            }
			setArrow(poseArrayCounter);
        }
	}

	private void setArrow(int poseArrayCounter)
	{
		SpriteRenderer poseArrow = GameObject.Find("PoseArrow").GetComponent<SpriteRenderer>();
		GameObject currentPose = generateMove.GetPoseGameObjects () [poseArrayCounter];
		poseArrow.transform.position = new Vector3(currentPose.transform.position.x,yArrow,0);
	}
}
