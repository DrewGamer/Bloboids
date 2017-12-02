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
    public GameObject slimeSpawner;

    public Text scoreText;
    public Text gameOverText;
    public static bool spawnBoss = false;

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
                SceneManager.LoadScene("Main_Menu");
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

    public static void IncreaseScore(float points)
    {
        //player gets more points based on how fast they are moving
        scoreMult = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().velocity.magnitude;
        //dont let the multiplier go below 1
        if (scoreMult < 1) scoreMult = 1;
        //calculate the points to be added, if it is below 1 make it at least 1
        int pointsAdded = (int)(points * scoreMult);
        if (pointsAdded < 1) pointsAdded = 1;

        //add points to the player score
        score += pointsAdded;

        //keeps track of when a player earns an extra life. every 500 points = 1 extra life
        //points over 500 carry over for the next extra life
        extraLife += pointsAdded;
        if (extraLife >= 500)
        {
            extraLife = 0 + extraLife % 500;
            spawnBoss = true;
            lives++;
        }

        //keeps track of when a player earns a special attack. every 100 points = 1 special attack
        //points over 100 carry over for the next special attack
        specialTracker += pointsAdded;
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
        extraLife = 0;
        specialTracker = 0;
        specialAttacks = 0;
        slimeSpawner.GetComponent<slime_spawner>().spawnRate = 30;


        gameOver = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy S");
        foreach (GameObject o in enemies)
        {
            Destroy(o);
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy M");
        foreach (GameObject o in enemies)
        {
            Destroy(o);
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy L");
        foreach (GameObject o in enemies)
        {
            Destroy(o);
        }
        enemies = GameObject.FindGameObjectsWithTag("BOSS");
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