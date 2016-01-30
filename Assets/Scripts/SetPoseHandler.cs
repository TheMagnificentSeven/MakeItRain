using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;
using System.Collections.Generic;

// Class that handles parsing of the JSON file
public class SetPoseHandler : MonoBehaviour {

	public List<Pose> handlePoseFile() {

		List<Pose> poseList = new List<Pose>();

		string contents = File.ReadAllText ("Assets/data/setPose.txt");
		var posesObject = JSON.Parse (contents);
		for (int i = 0; i < posesObject.Count; i++) {
			Pose p = new Pose ();
			p.setId(posesObject [i] ["id"]);
			p.setImageFile(posesObject [i] ["image"]);
			p.setLeftArm(posesObject [i] ["LeftArm"].AsInt);
			p.setRightArm(posesObject [i] ["RightArm"].AsInt);
			p.setLeftLeg(posesObject [i] ["LeftLeg"].AsInt);
			p.setRightLeg(posesObject [i] ["RightLeg"].AsInt);
			poseList.Add (p);
		}
		return poseList;
	}
}
