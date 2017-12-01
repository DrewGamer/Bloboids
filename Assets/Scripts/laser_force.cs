using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_force : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public GameObject explosion;

    // Use this for initialization
    void Start () {
        transform.Rotate(-180, -90, 90);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FixedUpdate()
    {
        if (lifeTime == 0)
        {
            Destroy(gameObject);
        }
        else
            lifeTime--;

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(target.gameObject);
            Destroy(gameObject);

            GameController_Script.IncreaseScore(1);
            Debug.Log(GameController_Script.GetScore());
        }
    }
}
