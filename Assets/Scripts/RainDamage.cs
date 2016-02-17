using UnityEngine;
using System.Collections;

public class RainDamage : MonoBehaviour {

    [SerializeField] private int damage;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    public int getDamage()
    {
        return damage;
    }
}
