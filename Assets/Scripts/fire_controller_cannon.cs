using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_controller_cannon : MonoBehaviour {

    public GameObject projectileCannon;
    public float spread;
    public int fireRate;
    private int timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && timer > fireRate)
        {
            
            Quaternion spawnRot = transform.rotation;
            //spawnRot.x = spawnRot.x + Random.Range(-spread, spread);

            Instantiate(projectileCannon, transform.position, spawnRot);
            gameObject.GetComponent<AudioSource>().Play();
            timer = 0;
        }
        else
            timer++;
    }
}
