using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController_Script : MonoBehaviour {

    public GameObject gameOverPanel;
    public GameObject scorePanel;
    public GameObject ship;
    public GameObject controlsPanel;
    public GameObject specialAttackPanel;
    public Text scoreText;
    public Text gameOverText;

    private static bool isDead = true;
    private static bool gameOver = false;
    private static int score = 0;
    private static int lives = 3;
    private static float scoreMult;

    private static int extraLife = 0;
    private static int specialTracker = 0;
    private static int specialAttacks = 0;

    private void Start()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        scoreText.GetComponent<Text>().material.color = new Color(scoreText.GetComponent<Text>().material.color.r, scoreText.GetComponent<Text>().material.color.g, scoreText.GetComponent<Text>().material.color.b, 100);
    }

    void Update()
    {
        scoreText.text = "Score: " + score + "\nLives: " + lives;
        if (lives <= 0)
        {
            gameOverText.text = "GAME OVER!" + "\nScore: " + score + "\nPlay again? (y/n)";
            gameOverPanel.SetActive(true);
            gameOver = true;
            Time.timeScale = 0;
        }

        if (specialAttacks > 0)
        {
            specialAttackPanel.SetActive(true);
        }
        else
        {
            specialAttackPanel.SetActive(false);
        }

        if (gameOver)
        {
            scorePanel.SetActive(false);
            if (Input.GetKey("y"))
            {
                NewGame();
            }
            else if (Input.GetKey("n"))
            {
                NewGame();
                Time.timeScale = 1;
                //SceneManager.LoadScene("house_scene");
                Application.Quit();
            }
        }

        if (isDead && !gameOver)
        {
            if (Input.GetKey("r"))
            {
                Time.timeScale = 1;
                Instantiate(ship, new Vector3(0, 0, 0), Quaternion.Euler(0,0,Random.Range(0,360)));
                controlsPanel.SetActive(false);
                isDead = false;
            }
        }

        /*
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        */
    }

    public static int GetScore()
    {
        return score;
    }

    public static int GetLives()
    {
        return lives;
    }

    public static int GetSpecialAttacks()
    {
        return specialAttacks;
    }

    public static void SetSpecialAttacks(int numAttacks)
    {
        specialAttacks += numAttacks;
    }

    public static void IncreaseScore(int points)
    {
        scoreMult = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity.magnitude;
        if (scoreMult < 1)
            scoreMult = 1;
        score += (int)(points * scoreMult);

        extraLife += (int)(points * scoreMult);
        if (extraLife >= 500)
        {
            extraLife = 0 + extraLife % 500;
            lives++;
        }

        specialTracker += (int)(points * scoreMult);
        if (specialTracker >= 100)
        {
            specialTracker = 0 + specialTracker % 100;
            specialAttacks++;
        }
    }

    public static void DecreaseLives()
    {
        lives--;
        isDead = true;
    }
    
    public void NewGame()
    {
        controlsPanel.SetActive(true);

        score = 0;
        lives = 3;
        gameOver = false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject o in enemies)
        {
            Destroy(o);
        }
        GameObject[] lasers = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject o in lasers)
        {
            Destroy(o);
        }

        gameOverPanel.SetActive(false);
        scorePanel.SetActive(true);
    }
}