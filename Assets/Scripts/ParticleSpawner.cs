using UnityEngine;
using System.Collections;

public class ParticleSpawner : MonoBehaviour {
    [SerializeField]
    ParticleSystem particlePrefab;

    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spawnParticles()
    {
        ParticleSystem newParticles = Instantiate(particlePrefab, transform.position, Quaternion.identity)
            as ParticleSystem;

        Debug.Log("Spawning particles");

        Destroy(newParticles.gameObject, newParticles.startLifetime);
    }
}
