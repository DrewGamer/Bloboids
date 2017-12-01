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
            Quaternion spawnRot = new Quaternion();
            switch (sideSelection)
            {
                case 0:
                    //topside asteroid spawn
                    Vector3 spawnLoc = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), 1, 0));
                    spawnLoc.z = 0;

                    GameObject asteroidTop = Instantiate(asteroid, spawnLoc, spawnRot);
                    break;
                case 1:
                    //botside asteroid spawn
                    spawnLoc = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), 0, 0));
                    spawnLoc.z = 0;

                    GameObject asteroidBot = Instantiate(asteroid, spawnLoc, spawnRot);
                    break;
                case 2:
                    //leftside asteroid spawn
                    spawnLoc = Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0.0f, 1.0f), 0));
                    spawnLoc.z = 0;

                    GameObject asteroidLeft = Instantiate(asteroid, spawnLoc, spawnRot);
                    break;
                case 3:
                    //rightside asteroid spawn
                    spawnLoc = Camera.main.ViewportToWorldPoint(new Vector3(1, Random.Range(0.0f, 1.0f), 0));
                    spawnLoc.z = 0;

                    GameObject asteroidRight = Instantiate(asteroid, spawnLoc, spawnRot);
                    break;

            }
        }
        
    }
}
