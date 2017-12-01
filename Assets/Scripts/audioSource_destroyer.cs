using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSource_destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().Play();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            Destroy(gameObject);
        }
		
	}
}
