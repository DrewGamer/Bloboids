using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_mover : MonoBehaviour {

    public int lifeTime;
    private int speed;

	// Use this for initialization
	void Start () {
        speed = Random.Range(1, 5);
        transform.LookAt(Vector3.zero);
        if (transform.rotation.eulerAngles.y > 91) transform.Rotate(Random.Range(-30,31), 0, 90);
        else transform.Rotate(new Vector3(Random.Range(-30, 31), 0, -90));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (lifeTime == 0)
        {
            Destroy(gameObject);
        }
        else
            lifeTime--;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
