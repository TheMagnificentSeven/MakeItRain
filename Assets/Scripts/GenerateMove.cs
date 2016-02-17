using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 public class GenerateMove : MonoBehaviour
 {

	Launch accessPose;
	List<Pose> posesFromJSON;
	List<Pose> generatedPoses;
	List<GameObject> poseGameObjects;
	private SpriteRenderer spriteRender;

	const int SCORE_TO_LEVEL_UP = 50;
	int totalPoses = 3; 

	float xOfFirstPose; 
	const float y = (float)(1.9);

	Pose currentPose;
    int lastIndex = -1;

    void Start() {
        accessPose = GetComponent<Launch> ();
		posesFromJSON = accessPose.GetPoses();
		generatedPoses = new List<Pose> ();
		poseGameObjects = new List<GameObject> ();
		//Generate ();
    }

	public void Generate() {
		generatedPoses.Clear ();
		totalPoses = CalculateTotalPoses ();

    	for(int i = 0; i < totalPoses ; i++) {
            int nextIndex;
            do
            {
                nextIndex = Random.Range(0, posesFromJSON.Count);
            } while (nextIndex == lastIndex);

			generatedPoses.Add(posesFromJSON[nextIndex]);
            lastIndex = nextIndex;
			if (poseGameObjects.Count > 0 && i < poseGameObjects.Count) {
				Destroy (poseGameObjects [i]);
			}
		}
		poseGameObjects.Clear ();
		InitX ();
		Show ();
    }

	public List<Pose> GetGeneratedPoseList() {
		return generatedPoses;
	}

	private int CalculateTotalPoses(){
		if (totalPoses >= 8)
			return 8;
		//return 3 + ScoreManager.score / SCORE_TO_LEVEL_UP;
		return ++totalPoses; //TODO FOR TESTING PURPOSES
	}

	void InitX(){
		xOfFirstPose = -1 * (int)Mathf.Ceil(totalPoses / 2);
		if (xOfFirstPose % 2 == 0)
			xOfFirstPose += 0.5f;
	}

	void Show(){
		//Debug.Log (Screen.width);
		for(int i = 0; i < totalPoses ; i++) {
			string img_num = generatedPoses[i].getId();
			GameObject pose_s = GameObject.Find("p_" + img_num);
			GameObject pos_s = (GameObject)Instantiate(pose_s, new Vector3(xOfFirstPose + i, y, 0), Quaternion.identity);
			poseGameObjects.Add (pos_s);
		}
	}

    void Update() {}

 }
