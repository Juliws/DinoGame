using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text hiScoreText;
    private int score;
    public int maxScore;
    private float timer;
    
    
    public static GameManager Instance { get; private set; }
    
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    void Update()
    {
        UpdateScore();
    }

    public void ShowgameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void UpdateScore()
    {
        int scorePerSec = 10;
        timer += Time.deltaTime;
        score = (int)(timer * scorePerSec);
        scoreText.text = string.Format("{0:00000}", score);
        
        
        hiScoreText.text = string.Format("HI {0:00000}", maxScore);
        //maxScore = score;

        if (score>maxScore)
        {
            maxScore = PlayerPrefs.GetInt("score", 0);
            
        }
        

    }

    private void hiScore()
    {
        float prevhiScore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > prevhiScore)
        {
            PlayerPrefs.SetFloat("hiscore", score);
        }
        
        float maxScore;
        maxScore = score;
        maxScore = PlayerPrefs.GetFloat("maxscore", 0);
        hiScoreText.text = string.Format("HI {0:00000}", maxScore);
    }
}
