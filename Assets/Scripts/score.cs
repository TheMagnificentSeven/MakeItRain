using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour {
    [SerializeField]
    GameObject textbox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setScore(int score)
    {
        textbox.GetComponent<Text>().text = "Score: " + score;
    }
}
