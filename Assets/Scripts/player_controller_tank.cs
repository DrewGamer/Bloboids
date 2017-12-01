using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller_tank : MonoBehaviour
{

    public int acceleration;
    public int turnSpeed;
    public float topSpeed;
    public GameObject turret;
    public GameObject superNova;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // control for special attack
        if (Input.GetKeyDown("space") && GameController_Script.GetSpecialAttacks() > 0)
        {
            Instantiate(superNova, transform.position, superNova.transform.rotation, transform);
            GameController_Script.SetSpecialAttacks(-1);

        }

        //Rotate turret object to face mouse

        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        turret.transform.rotation = Quaternion.Euler(new Vector3(180, 0, -angle));

        if (Input.GetKey("w"))
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * acceleration);
        }

        if (Input.GetKey("s"))
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.down * acceleration);
        }

        if (GetComponent<Rigidbody>().velocity.magnitude > topSpeed)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * topSpeed;
        }

        // rotate via keyboard
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed);
        }

        // if the player moves out of the screen bounds, they appear on the opposite side of the screen
        // this is for right side
        if (Camera.main.WorldToViewportPoint(transform.position).x > 1.0f)
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, Camera.main.WorldToViewportPoint(transform.position).y, Camera.main.WorldToViewportPoint(transform.position).z)); ;
        // this is for left side
        if (Camera.main.WorldToViewportPoint(transform.position).x < 0.0f)
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, Camera.main.WorldToViewportPoint(transform.position).y, Camera.main.WorldToViewportPoint(transform.position).z));
        // this is for top side
        if (Camera.main.WorldToViewportPoint(transform.position).y > 1.0f)
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Camera.main.WorldToViewportPoint(transform.position).x, 0.0f, Camera.main.WorldToViewportPoint(transform.position).z));
        // this is for bottom side
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0.0f)
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Camera.main.WorldToViewportPoint(transform.position).x, 1.0f, Camera.main.WorldToViewportPoint(transform.position).z));
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            GameController_Script.DecreaseLives();
            //Instantiate(ship, new Vector3(0, 0, -11), transform.rotation);
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}
