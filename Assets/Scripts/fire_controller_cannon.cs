using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_controller_cannon : MonoBehaviour {

    public GameObject projectileCannon;
    public int fireRate;
    private int timer;

    private void FixedUpdate()
    {
        if (GameController_Script.GameTime.isPaused)
            return;

        if (Input.GetButton("Fire1") && timer > fireRate)
        {
            Quaternion spawnRot = transform.rotation;

            Instantiate(projectileCannon, transform.position, spawnRot);
            gameObject.GetComponent<AudioSource>().Play();
            timer = 0;
        }
        else
            timer++;
    }
}
