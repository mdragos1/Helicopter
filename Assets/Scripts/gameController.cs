using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{

    public static gameController instance;          
    public Text scoreText;                        
    public GameObject gameOvertext;                

    private int score = 0;                        
    public bool gameOver = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.touchCount>0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            var scenaJoc = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scenaJoc);
            Time.timeScale = 1;
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
        gameOvertext.SetActive(true);
        gameOver = true;
        Time.timeScale = 0;
    }
}
