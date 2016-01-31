using UnityEngine;
using System.Collections;

public class RainWatcher : MonoBehaviour {

    [SerializeField] private int damage;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y <= -10)
        {
            Debug.Log("object destroyed!");
            Destroy(gameObject);
        }
    }

    public int getDamage()
    {
        return damage;
    }
}
