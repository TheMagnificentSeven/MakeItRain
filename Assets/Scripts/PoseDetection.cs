using UnityEngine;
using System.Collections.Generic;

public class PoseDetection : MonoBehaviour {
	Launch launchHandler;
	float threshold = 20;
	int poseArrayCounter;
	GenerateMove generateMove;
	List<Pose> listOfGenPose;
	private int correctCount; 

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
		}
		if (poseArrayCounter > listOfGenPose.Count - 1) {
			//Debug.Log (listOfGenPose.Count);
			//Debug.Log ("Resetting");
			poseArrayCounter = -1;
			return;
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
            // Next Pose
            poseArrayCounter++;   //new
            setArrow(poseArrayCounter);

            // Celebratory sparkles
            GameObject.Find("DancingLightsSpawner").GetComponent<ParticleSpawner>().spawnParticles();

            // We've finished three poses, make it rain!
            if (poseArrayCounter % 3 == 0)
            {
                GameObject.Find("BigDancingLightsSpawner").GetComponent<ParticleSpawner>().spawnParticles();
                GameObject.Find("BackgroundImage").GetComponent<MakeItRain>().Rain();
            }
        }
        if (ScoreManager.score > 50)
        {
            lastDance();
        }
	}

    private void lastDance()
    {
        GameObject.Find("BackgroundImage").GetComponent<MakeItRain>().continuousRain();
    }

	private void setArrow(int poseArrayCounter)
	{
		SpriteRenderer leftarrow = GameObject.Find("leftarrow").GetComponent<SpriteRenderer>();
		SpriteRenderer midarrow = GameObject.Find("midarrow").GetComponent<SpriteRenderer>();
		SpriteRenderer rightarrow = GameObject.Find("rightarrow").GetComponent<SpriteRenderer>();

		switch (poseArrayCounter%3)
		{
		case 0:
			leftarrow.enabled = true;
			midarrow.enabled = false;
			rightarrow.enabled = false;
			break;
		case 1:
			leftarrow.enabled = false;
			midarrow.enabled = true;
			rightarrow.enabled = false;
			break;
		case 2:
			leftarrow.enabled = false;
			midarrow.enabled = false;
			rightarrow.enabled = true;
			break;
		}
	}
}
