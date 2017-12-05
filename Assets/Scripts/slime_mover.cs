using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_mover : MonoBehaviour {

    public int lifeTime;
    public GameObject largeSlime;
    public GameObject mediumSlime;
    public GameObject smallSlime;

    public float life;
    private int speed;

    public bool canMerge = true;
    public bool collisionInst = false;

	// Use this for initialization
	void Start () {
        speed = Random.Range(1, 5);
        transform.LookAt(Vector3.zero);
        if (transform.rotation.eulerAngles.y > 91) transform.Rotate(Random.Range(-30,31), 0, 90);
        else transform.Rotate(new Vector3(Random.Range(-30, 31), 0, -90));

        if (gameObject.tag == "Enemy S")
            life = 1;
        else if (gameObject.tag == "Enemy M")
            life = 2;
        else if (gameObject.tag == "Enemy L")
            life = 4;
    }

    private void FixedUpdate()
    {
        if (GameController_Script.GameTime.isPaused)
            return;

        if (lifeTime == 0)
            Destroy(gameObject);
        else
            lifeTime--;

        if (lifeTime < 700)
            canMerge = true;

        transform.Translate(Vector3.forward * GameController_Script.GameTime.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Enemy S" && gameObject.tag == "Enemy S" && canMerge && collisionInst)
        {
            Destroy(target.gameObject);
            GameObject slime = Instantiate(mediumSlime, transform.position, transform.rotation);
            slime.GetComponent<slime_mover>().canMerge = false;
            Destroy(gameObject);
        }
        else if (target.gameObject.tag == "Enemy M" && gameObject.tag == "Enemy M" && canMerge && collisionInst)
        {
            Destroy(target.gameObject);
            GameObject slime = Instantiate(largeSlime, transform.position, transform.rotation);
            slime.GetComponent<slime_mover>().canMerge = false;
            Destroy(gameObject);
        }
        else if (target.gameObject.tag == gameObject.tag && canMerge)
        {
            target.GetComponent<slime_mover>().collisionInst = true;
            Destroy(gameObject);
        }
    }
}
