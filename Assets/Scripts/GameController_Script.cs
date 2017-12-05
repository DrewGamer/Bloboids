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

    public GameObject menuPanel;
    public GameObject pauseControlsPanel;

    public Text scoreText;
    public Text gameOverText;

    public static bool spawnBoss;

    private static bool isDead;
    private static bool gameOver;
    private static int score;
    private static int lives;
    private static float scoreMult;

    private static int extraLife;
    private static int specialTracker;
    private static int specialAttacks;

    private void Start()
    {
        NewGame();
        Time.timeScale = 0;
        //GameTime.isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public static class GameTime
    {
        public static bool isPaused = false;
        public static float deltaTime
        {
            get
            {
                return isPaused ? 0 : Time.deltaTime;
            }
        }
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
            //GameTime.isPaused = true;
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
                //GameTime.isPaused = false;
                SceneManager.LoadScene("Main_Menu");
            }
        }

        if (isDead && !gameOver)
        {
            if (Input.GetKey("r"))
            {
                Time.timeScale = 1;
                //GameTime.isPaused = false;
                Instantiate(ship, new Vector3(0, 0, 0), Quaternion.Euler(0,0,Random.Range(0,360)));
                controlsPanel.SetActive(false);
                isDead = false;
            }
        }

        if (Input.GetKeyDown("escape") && menuPanel.activeSelf == false)
        {
            Time.timeScale = 0;
            GameTime.isPaused = true;
            menuPanel.SetActive(true);
        }
        else if (Input.GetKeyDown("escape") && menuPanel.activeSelf == true)
        {
            Time.timeScale = 1;
            GameTime.isPaused = false;
            menuPanel.SetActive(false);
        }
    }

    public void ButtonPress(GameObject aButton)
    {
        
        if (aButton.GetComponent<Button>().name.Equals("ExitButton"))
        {
            Time.timeScale = 1;
            GameTime.isPaused = false;
            NewGame();
            SceneManager.LoadScene("Main_Menu");
        }
        else if (aButton.GetComponent<Button>().name.Equals("HowToPlayButton"))
        {
            menuPanel.SetActive(false);
            pauseControlsPanel.SetActive(true);
        }
        else if (aButton.GetComponent<Button>().name.Equals("BackButton"))
        {
            menuPanel.SetActive(true);
            pauseControlsPanel.SetActive(false);
        }
        else if (aButton.GetComponent<Button>().name.Equals("ResumeButton"))
        {
            Time.timeScale = 1;
            GameTime.isPaused = false;
            menuPanel.SetActive(false);
        }
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
        //points over 250 carry over for the next special attack
        specialTracker += pointsAdded;
        if (specialTracker >= 250)
        {
            specialTracker = 0 + specialTracker % 250;
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

        spawnBoss = false;
        isDead = true;

        extraLife = 0;
        specialTracker = 0;
        specialAttacks = 0;

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