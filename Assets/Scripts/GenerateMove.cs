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
	float x; 
	float y = (float)(1.9);
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
		return 3 + ScoreManager.score / SCORE_TO_LEVEL_UP;
	}

	void InitX(){
		x = -1 * (int)Mathf.Ceil(totalPoses % 2);
	}

	void SetX(){
		x += 1;
	}

	void Show(){
		//Debug.Log (Screen.width);
		for(int i = 0; i < totalPoses ; i++) {
			string img_num = generatedPoses[i].getId();
			GameObject pose_s = GameObject.Find("p_" + img_num);
			GameObject pos_s = (GameObject)Instantiate(pose_s, new Vector3(x, y, 0), Quaternion.identity);
			poseGameObjects.Add (pos_s);
			SetX ();
		}
	}

    void Update() {}

 }
