using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControllerScript : MonoBehaviour {

    private int blobTimer;
    public GameObject menuBlob1;
    public GameObject menuBlob2;

	// Use this for initialization
	void Start () {
        blobTimer = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        blobTimer++;
        Debug.Log(blobTimer);
        if (blobTimer > 1000)
        {
            menuBlob1.GetComponent<slime_mover>().enabled = true;
            menuBlob2.GetComponent<slime_mover>().enabled = true;
        }
    }

    public void ButtonPress(GameObject aButton)
    {
        if (aButton.GetComponent<Button>().name.Equals("StartButton"))
        {
            blobTimer = 0;
            SceneManager.LoadScene("Game_Scene");
        }
        else if (aButton.GetComponent<Button>().name.Equals("ExitButton"))
        {
            Application.Quit();
        }
    }
}
