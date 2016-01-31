using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 public class GenerateMove : MonoBehaviour
 {

	Launch accessPose;
	List<Pose> poses;
	List<Pose> poseList;
	List<GameObject> listOfPoseGameObject;
	private SpriteRenderer spriteRender;

	int numPose = 3; float x; float y = (float)(1.9);
	Pose currentPose;
    int lastIndex = -1;

    void Start() {
        accessPose = GetComponent<Launch> ();
		poses = accessPose.GetPose ();
		poseList = new List<Pose> ();
		listOfPoseGameObject = new List<GameObject> ();
		//Generate ();
    }

	public void Generate() {
		poseList.Clear ();
    	for(int i = 0; i < numPose ; i++) {
            int nextIndex;
            do
            {
                nextIndex = Random.Range(0, poses.Count);
            } while (nextIndex == lastIndex);

			poseList.Add(poses[nextIndex]);
            lastIndex = nextIndex;
			if (listOfPoseGameObject.Count > 0) {
				Destroy (listOfPoseGameObject [i]);
			}
		}
		listOfPoseGameObject.Clear ();
		InitX ();
		Show ();
    }

	public List<Pose> GetGeneratedPoseList() {
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
		//Debug.Log (Screen.width);
		for(int i = 0; i < numPose ; i++) {
			string img_num = poseList[i].getId();
			GameObject pose_s = GameObject.Find("p_" + img_num);
			GameObject pos_s = (GameObject)Instantiate(pose_s, new Vector3(x, y, 0), Quaternion.identity);
			listOfPoseGameObject.Add (pos_s);
			SetX ();
		}
	}

    void Update() {}

 }
