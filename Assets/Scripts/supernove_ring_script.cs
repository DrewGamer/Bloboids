using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supernove_ring_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().Play();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        GetComponent<SphereCollider>().radius += 0.08f;
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            Destroy(target.gameObject);

            GameController_Script.IncreaseScore(1);
            Debug.Log(GameController_Script.GetScore());
        }
    }
}
