using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_boss : MonoBehaviour {

    public GameObject largeSlime;
    public GameObject mediumSlime;
    public GameObject smallSlime;

    public float life;

    private int spawnTimer = 0;
    private int speed;

	// Use this for initialization
	void Start () {
        speed = 1;
        transform.LookAt(new Vector3(0.51f, 0.7f, 0));
        if (transform.rotation.eulerAngles.y > 91) transform.Rotate(0, 0, 90);
        else transform.Rotate(new Vector3(0, 0, -90));
        life = 50;
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    private void FixedUpdate()
    {
        if (Vector3.Magnitude(transform.position - Camera.main.ViewportToWorldPoint(new Vector3(0.51f, 0.7f, 10))) > 1)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        else GetComponentInChildren<Animation>().Play("Wait");

        if (spawnTimer > 5)
        {
            GameObject slime = Instantiate(smallSlime, transform.position + new Vector3(Random.Range(-3f,3f), Random.Range(-3f,2f), 0), transform.rotation);
            slime.transform.rotation = Random.rotation;
            slime.GetComponent<slime_mover>().canMerge = false;
            spawnTimer = 0;
        }
        else
            spawnTimer++;
        
    }
}
