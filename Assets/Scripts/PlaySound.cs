using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	private AudioSource sound01;
	private const string MAIN_CAMERA = "MainCamera";
	private bool _isRendered = false;
	private bool _firstTime = true;

	void Start () {
		sound01 = GetComponent<AudioSource>();
	}

	void Update () {
		if(_isRendered&&_firstTime) {
			sound01.PlayOneShot(sound01.clip);
			_firstTime = false;
		}
	}
		
	private void OnWillRenderObject(){
		if (Camera.current.tag == MAIN_CAMERA) {
			_isRendered = true;
		}
	}
}