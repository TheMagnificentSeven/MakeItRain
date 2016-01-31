using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour {
    [SerializeField]
    GameObject textbox;

	// Use this for initialization
	void Start ()
    {
        textbox.GetComponent<Text>().text = "Score: " + ScoreManager.score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
