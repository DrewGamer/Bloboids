using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supernova_script : MonoBehaviour {

    public GameObject supernovaRing;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().Play();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            if (transform.parent != null)
            {
                Instantiate(supernovaRing, transform.parent.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(supernovaRing, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            
        }

    }
}
