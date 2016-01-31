using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 public class GenerateMove : MonoBehaviour
 {

	Launch accessPose;
	List<Pose> poses;
	List<Pose> poseList;
	private SpriteRenderer spriteRender;

	int numPose = 3; float x; float y = (float)(1.9);
	Pose currentPose;

    void Start() {
        accessPose = GetComponent<Launch> ();
		poses = accessPose.GetPose ();
		poseList = new List<Pose> ();
		Generate ();
		InitX ();
		Show ();
    }

	void Generate() {
		poseList.Clear ();
    	for(int i = 0; i < numPose ; i++) {
			poseList.Add(poses[Random.Range(0, poses.Count)]);
			}
    }

	public List<Pose> getGeneratedPoseLists() {
		return poseList;
	}

	void IncPose(){
		numPose += 2;
	}

	void InitX(){
		x = -1 * (int)Mathf.Ceil(numPose % 2);
	}

	void SetX(){
		x += 1;
	}

	void Show(){
		Debug.Log (Screen.width);
		for(int i = 0; i < numPose ; i++) {
			string img_num = poseList[i].getId();
			GameObject pose_s = GameObject.Find("p_" + img_num);
			GameObject pos_s = (GameObject)Instantiate(pose_s, new Vector3(x, y, 0), Quaternion.identity);
			SetX ();
		}
	}

    void Update() {}

 }
