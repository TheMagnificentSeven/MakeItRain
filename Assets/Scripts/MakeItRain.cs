using UnityEngine;
using System.Collections;

public class MakeItRain : MonoBehaviour {

    private int numObjects = 10;
    private float minX = 0f;
    private float maxX = 800f;
    public GameObject rain;
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    void Rain () {
        BoxCollider2D rainCol = rain.GetComponent<BoxCollider2D>().size.x;
        float x_pos = Random.Range(minX, maxX - rainCol.size.x);
        for (int i = 0; i < numObjects; i++)
            Instantiate(rain, new Vector3(x_pos, rain.transform.position.y, rain.transform.position.z), rain.transform.rotation);
    }
}
