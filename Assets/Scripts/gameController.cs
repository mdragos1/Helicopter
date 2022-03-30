using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class gameController : MonoBehaviour
{
    public building cladire;
    public static gameController instance;          
    public Text scoreText;   
    public Text highscoreText;                        
    public GameObject gameOvertext;
    public GameObject hsHolder;
    public Text playAgain;

    private float nextSpawnTime;
    private int score = 0;
    private int hs;
    public bool gameOver = false;
    public float offset = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        if (PlayerPrefs.HasKey("highscore") == true)
        {
            print("are hs");
            hs = PlayerPrefs.GetInt("highscore");
            print("are hs: "+ hs);
        }
        else
        {
            PlayerPrefs.SetInt("highscore", 0);
            hs = 0;
        }
        //PlayerPrefs.Save();
        nextSpawnTime = Time.time + offset;
        highscoreText.text ="HighScore: " + hs.ToString();
        Time.timeScale = 0;
        gameOvertext.SetActive(true);
        gameOvertext.GetComponentInChildren<Text>().text = "Tap to start";
        playAgain.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            building clone = Instantiate(cladire, cladire.transform.position, Quaternion.identity);
            nextSpawnTime += offset;
            Destroy(clone,15);
        }
        if(!gameOver && Input.touchCount > 0)
        {
            gameOvertext.SetActive(false);
            gameOvertext.GetComponentInChildren<Text>().text = "Game Over";
            Time.timeScale = 1;
        }
        
        if (gameOver && Input.touchCount>0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                var scenaJoc = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scenaJoc);
                Time.timeScale = 1;
            }
            
        }
    }
    public void Scored()
    {
        if(gameOver == true)  
            return;
        score++;
        scoreText.text = score.ToString();
    }
    public void Crashed()
    {
        if (score > hs)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            hs = score;
        }
        playAgain.text = "Tap to play again";
        highscoreText.text = "HighScore: " + hs.ToString();
        hsHolder.SetActive(true);
        gameOvertext.SetActive(true);
        gameOver = true;
        Time.timeScale = 0;
    }
}
