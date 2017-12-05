using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControllerScript : MonoBehaviour {

    private int blobTimer;
    private bool blobsMoved;
    public GameObject menuPanel;
    public GameObject controlsPanel;

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
        else if (aButton.GetComponent<Button>().name.Equals("HowToPlayButton"))
        {
            menuPanel.SetActive(false);
            controlsPanel.SetActive(true);
        }
        else if (aButton.GetComponent<Button>().name.Equals("BackButton"))
        {
            menuPanel.SetActive(true);
            controlsPanel.SetActive(false);
        }
    }
}
