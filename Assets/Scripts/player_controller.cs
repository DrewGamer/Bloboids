using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

    public int acceleration;
    public int turnSpeed;
    public float topSpeed;
    public GameObject ship;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        //Rotate object to face mouse
        
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        

        if (Input.GetKey("w"))
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * acceleration); 
        }

        if (GetComponent<Rigidbody>().velocity.magnitude > topSpeed)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * topSpeed;
        }

        /* old code to rotate via keyboard
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed);
        }

        /* trying to get a 180 flip from direction of motion
        if (Input.GetKey("s"))
        {
            Debug.Log(GetComponent<Rigidbody>().velocity);

            transform.rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.normalized);
        }
        */

        if (transform.position.x > 4.3f)
            transform.position = new Vector3(-4.3f,transform.position.y,transform.position.z);
        if (transform.position.x < -4.3f)
            transform.position = new Vector3(4.3f, transform.position.y, transform.position.z);

        if (transform.position.y > 3.3f)
            transform.position = new Vector3(transform.position.x, -3.3f, transform.position.z);
        if (transform.position.y < -3.3f)
            transform.position = new Vector3(transform.position.x, 3.3f, transform.position.z);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            GameController_Script.DecreaseLives();
            //Instantiate(ship, new Vector3(0, 0, -11), transform.rotation);
            Destroy(target.gameObject);
            Destroy(gameObject);
            Debug.Log(GameController_Script.GetLives());
        }
    }
}
