using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] static int highScore;

    [SerializeField] Text highScoreText;
    [SerializeField] Text scoreCount;
    // score at game over panel
    [SerializeField] Text gameOverScoureCount;

    [SerializeField] public  bool isOver;
    [SerializeField] public bool isPause;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;



    // for mobile  access by the player contoller script
    [SerializeField] public Text exitText;
    [SerializeField] public Text restartText;
    [SerializeField] public Text continueText;
    [SerializeField] public Text tapToPlayText;

    [SerializeField] GameObject taToPlayPanel; 

    private void Awake()
    {
        scoreCount.text = "Score:" + 00;
    }
    private void Start()
    {
        taToPlayPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    void Update()
    {
        //R to reload
        if (Input.GetKeyDown(KeyCode.R) && isPause)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
        //escape to pausse 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        // F4 to quit  if game  is already pause 
        if (Input.GetKeyDown(KeyCode.F4) && isPause)
        {
            Quit();
        }
       if (Input.GetKeyDown(KeyCode.Space  ) )
        {
            TapToPlay();
        }

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            score++;
            scoreCount.text = "Score:" + score;
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void Quit()
    {
        Debug.Log("I  quit ");
        Application.Quit();
    }

    private void HighScore()
    {
        highScoreText.text = "HighScore:" + PlayerPrefs.GetInt("highScore", highScore);
        //score on game over panel
        gameOverScoureCount.text = "Score:" + score.ToString();
    }
    public void GameOver()
    {
        isOver = true;
        HighScore();
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Pause()
    {
        if (!isPause && !isOver)
        {
            isPause = true;
            //pause panel active 
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (isPause && !isOver)
        {
            isPause = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void TapToPlay()
    {
        Time.timeScale = 1f;
        taToPlayPanel.SetActive(false);
    }
}
