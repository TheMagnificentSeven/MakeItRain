using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// The first script that runs when you launch the game
public class Launch : MonoBehaviour {

	List<Pose> poses;

	// Use this for initialization
	void Start () {
		// Calls the script that handles the importing of poses
		SetPoseHandler setPoseHandler;
		setPoseHandler = GetComponent<SetPoseHandler> ();

		// Contains list of the set poses parsed from the file
		poses = setPoseHandler.handlePoseFile();
		//Debug.Log (poses[1].getLeftArm());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public List<Pose> GetPoses() {
		return poses;
	}
}
