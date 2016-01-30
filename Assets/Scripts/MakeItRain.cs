using UnityEngine;
using System.Collections;

public class MakeItRain : MonoBehaviour
{

    private int numObjects = 10;
    private float minX = -4f;
    private float maxX = 4f;
    private GameObject rain;
    private GameObject rainClone;


    // Use this for initialization
    void Start()
    {
        // Here only for test
        Rain();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Rain()
    {
        int whichRain = Random.Range(1, 4);
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

        float x_pos = Random.Range(minX, maxX - rain.GetComponent<BoxCollider2D>().size.x);
        for (int i = 0; i < numObjects; i++)
        {
            rainClone = (GameObject)Instantiate(rain, new Vector3(x_pos, rain.transform.position.y, rain.transform.position.z), rain.transform.rotation);
            rainClone.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
