using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_destroyer : MonoBehaviour {

    public GameObject audioObject;

    // Use this for initialization
    void Start () {
        Instantiate(audioObject, transform.position, transform.rotation);

    }
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(gameObject);
        }
		
	}
    
    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            Destroy(target.gameObject);

            GameController_Script.IncreaseScore(1);
            Debug.Log(GameController_Script.GetScore());
        }
    }
    
}
