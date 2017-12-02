using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_force_gun : MonoBehaviour {

    public float speed;
    public float lifeTime;

    public GameObject largeSlime;
    public GameObject mediumSlime;
    public GameObject smallSlime;

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
        if (target.gameObject.tag.Contains("Enemy"))
        {
            target.GetComponent<slime_mover>().life -= 0.4f;
            if (target.GetComponent<slime_mover>().life <= 0)
            {
                if (target.gameObject.tag == "Enemy S")
                    GameController_Script.IncreaseScore(1);
                else if (target.gameObject.tag == "Enemy M")
                {
                    GameController_Script.IncreaseScore(2);
                    GameObject slime = Instantiate(smallSlime, transform.position, transform.rotation);
                    slime.GetComponent<slime_mover>().canMerge = false;
                }
                else if (target.gameObject.tag == "Enemy L")
                {
                    GameController_Script.IncreaseScore(3);
                    GameObject slime = Instantiate(mediumSlime, transform.position, transform.rotation);
                    slime.GetComponent<slime_mover>().canMerge = false;
                }

                Debug.Log(GameController_Script.GetScore());

                Destroy(target.gameObject);
            }
            Destroy(gameObject);
        }
        else if (target.gameObject.tag == "BOSS")
        {
            target.GetComponent<slime_boss>().life -= 0.4f;
            if (target.GetComponent<slime_boss>().life <= 0)
            {
                GameController_Script.IncreaseScore(20);
                Debug.Log(GameController_Script.GetScore());

                Destroy(target.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
