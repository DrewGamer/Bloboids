using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_controller_gun : MonoBehaviour {

    public GameObject projectileGun;
    public float spread;
    public int fireRate;
    private int timer;

    private void FixedUpdate()
    {
        if (GameController_Script.GameTime.isPaused)
            return;

        if (Input.GetButton("Fire2") && timer > fireRate)
        {

            Quaternion spawnRot = transform.rotation;
            spawnRot.x = spawnRot.x + Random.Range(-spread, spread);

            Instantiate(projectileGun, transform.position, spawnRot);
            gameObject.GetComponent<AudioSource>().Play();
            timer = 0;
        }
        else
            timer++;
    }
}
