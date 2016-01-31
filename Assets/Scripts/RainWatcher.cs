using UnityEngine;
using System.Collections;

public class RainWatcher : MonoBehaviour {

    private int damage;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y <= -10)
            Destroy(gameObject);
    }

    public int getDmg()
    {
        return damage;
    }

    public void setDmg(int value)
    {
       damage = value;
    }
}
