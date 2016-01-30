using UnityEngine;
using System.Collections;

public class Pose {

	string id;
	string imageFile; // The filename of the image
	int leftArm;
	int rightArm;
	int leftLeg;
	int rightLeg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setId(string id) {
		this.id = id;
	}

	public void setImageFile(string imageFile) {
		this.imageFile = imageFile;
	}

	public void setLeftArm(int leftArm) {
		this.leftArm = leftArm;
	}

	public void setRightArm(int rightArm) {
		this.rightArm = rightArm;
	}

	public void setLeftLeg(int leftLeg) {
		this.leftLeg = leftLeg;
	}

	public void setRightLeg(int rightLeg) {
		this.rightLeg = rightLeg;
	}

	public string getId() {
		return id;
	}

	public string getImage() {
		return imageFile;
	}

	public int getLeftArm() {
		return leftArm;
	}

	public int getRightArm() {
		return rightArm;
	}

	public int getLeftLeg() {
		return leftLeg;
	}

	public int getRightLeg() {
		return rightLeg;
	}
}
