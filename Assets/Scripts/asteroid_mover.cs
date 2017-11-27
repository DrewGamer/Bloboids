using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_mover : MonoBehaviour {

    public int lifeTime;
    public GameObject ship;
    private int speed;

	// Use this for initialization
	void Start () {
        speed = Random.Range(1, 5);
        transform.LookAt(ship.transform.position);
        transform.Rotate(new Vector3(Random.Range(-30,31),0,0));

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (transform.rotation.y > 0)
        {
            transform.Rotate(0, -180, 0);
        }
        if (lifeTime == 0)
        {
            Destroy(gameObject);
        }
        else
            lifeTime--;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
