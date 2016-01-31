using UnityEngine;
using System.Collections;

public class MakeItRain : MonoBehaviour
{

    private int numObjects = 20;
    private float minX = -4f;
    private float maxX = 4f;
    private GameObject rain;
    private GameObject rainClone;
    int count = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    // Just for test
    void Update()
    {

    }

    // Called only when dance is finished
    public void Rain()
    {
        int whichRain = Random.Range(10, 15);
        switch (whichRain)
        {
            case 1:
                rain = GameObject.Find("Rain/healObj");
                break;
            case 2:
                rain = GameObject.Find("Rain/safeObj");
                break;
            case 3: 
                rain = GameObject.Find("Rain/mediumObj");
                break;
             default:
                rain = GameObject.Find("Rain/dangerousObj");
                break;
        }

        for (int i = 0; i < numObjects; i++)
        {
            float x_rand = Random.Range(minX, maxX - rain.GetComponent<BoxCollider2D>().size.x);
            float y_rand = Random.Range(1f, 3f);
            rainClone = (GameObject) Instantiate(rain, new Vector3(x_rand, rain.transform.position.y - y_rand, rain.transform.position.z), rain.transform.rotation);
            rainClone.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}