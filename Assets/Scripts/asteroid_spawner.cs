using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_spawner : MonoBehaviour {

    public GameObject asteroid;
    private int timer;

	// Use this for initialization
	void Start () {
        timer = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate()
    {
        timer++;
        if (timer > 30)
        {
            timer = 0;
            int sideSelection = Random.Range(0, 4);
            switch (sideSelection)
            {
                case 0:
                    //topside asteroid spawn
                    Quaternion spawnRot = Random.rotation;
                    Vector3 spawnLoc = transform.position;
                    spawnLoc.z = 0;
                    spawnLoc.x = Random.Range(-5.0f, 6.0f);
                    spawnLoc.y = 5;

                    float scale = Random.Range(0.1f, 0.5f);

                    GameObject asteroidTop = Instantiate(asteroid, spawnLoc, spawnRot);
                    asteroidTop.transform.localScale = new Vector3(scale, scale, scale);
                    break;
                case 1:
                    //botside asteroid spawn
                    spawnRot = Random.rotation;
                    spawnLoc = transform.position;
                    spawnLoc.z = 0;
                    spawnLoc.x = Random.Range(-5.0f, 6.0f);
                    spawnLoc.y = -5;

                    scale = Random.Range(0.1f, 0.5f);

                    GameObject asteroidBot = Instantiate(asteroid, spawnLoc, spawnRot);
                    asteroidBot.transform.localScale = new Vector3(scale, scale, scale);
                    break;
                case 2:
                    //leftside asteroid spawn
                    spawnRot = Random.rotation;
                    spawnLoc = transform.position;
                    spawnLoc.z = 0;
                    spawnLoc.x = -5;
                    spawnLoc.y = Random.Range(-5.0f, 6.0f);

                    scale = Random.Range(0.1f, 0.5f);

                    GameObject asteroidLeft = Instantiate(asteroid, spawnLoc, spawnRot);
                    asteroidLeft.transform.localScale = new Vector3(scale, scale, scale);
                    break;
                case 3:
                    //rightside asteroid spawn
                    spawnRot = Random.rotation;
                    spawnLoc = transform.position;
                    spawnLoc.z = 0;
                    spawnLoc.x = 5;
                    spawnLoc.y = Random.Range(-5.0f, 6.0f);

                    scale = Random.Range(0.1f, 0.5f);

                    GameObject asteroidRight = Instantiate(asteroid, spawnLoc, spawnRot);
                    asteroidRight.transform.localScale = new Vector3(scale, scale, scale);
                    break;

            }
        }
        
    }
}
