using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_spawner : MonoBehaviour {

    public GameObject slime;
    public GameObject boss;
    private int timer;
    public float spawnRate;
    private int spawnRateTimer;

	// Use this for initialization
	void Start () {
        timer = 0;
        spawnRateTimer = 0;
        spawnRate = 30;
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate()
    {
        timer++;
        spawnRateTimer++;
        if (spawnRateTimer > 2000)
        {
            spawnRate *= 0.8f;
            spawnRateTimer = 0;
        }
            

        if (timer > spawnRate)
        {
            timer = 0;
            int sideSelection = Random.Range(0, 4);
            Quaternion spawnRot = new Quaternion();
            switch (sideSelection)
            {
                case 0:
                    //topside slime spawn
                    Vector3 spawnLoc = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), 1, 0));
                    spawnLoc.z = 0;

                    GameObject slimeTop = Instantiate(slime, spawnLoc, spawnRot);
                    break;
                case 1:
                    //botside slime spawn
                    spawnLoc = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), 0, 0));
                    spawnLoc.z = 0;

                    GameObject slimeBot = Instantiate(slime, spawnLoc, spawnRot);
                    break;
                case 2:
                    //leftside slime spawn
                    spawnLoc = Camera.main.ViewportToWorldPoint(new Vector3(0, Random.Range(0.0f, 1.0f), 0));
                    spawnLoc.z = 0;

                    GameObject slimeLeft = Instantiate(slime, spawnLoc, spawnRot);
                    break;
                case 3:
                    //rightside slime spawn
                    spawnLoc = Camera.main.ViewportToWorldPoint(new Vector3(1, Random.Range(0.0f, 1.0f), 0));
                    spawnLoc.z = 0;

                    GameObject slimeRight = Instantiate(slime, spawnLoc, spawnRot);
                    break;

            }
        }
        if (GameController_Script.spawnBoss)
        {
            Quaternion spawnRot = new Quaternion();
            Vector3 spawnLoc = Camera.main.ViewportToWorldPoint(new Vector3(0.51f, 1, 0));
            spawnLoc.z = 0;

            GameObject slimeBoss = Instantiate(boss, spawnLoc, spawnRot);
            GameController_Script.spawnBoss = false;
        }
        
    }
}
