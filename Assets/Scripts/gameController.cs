using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public building cladire;
    public static gameController instance;          
    public Text scoreText;                        
    public GameObject gameOvertext;

    private float nextSpawnTime;
    private int score = 0;                        
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
        
        nextSpawnTime = Time.time + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(cladire, cladire.transform.position, Quaternion.identity);
            nextSpawnTime += offset;
        }
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
