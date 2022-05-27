using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    public int playerLives = 10;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public int score = 0;


    void Awake()
    {
        Debug.Log(score);
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    void Start() 
    {
        livesText.text = playerLives.ToString();   
        scoreText.text = score.ToString(); 
    }

    void Update() 
    {
        livesText.text = playerLives.ToString();   
        scoreText.text = score.ToString(); 
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }else
        {
            score = 0;
            scoreText.text = score.ToString(); 
            LoseSession();
            //ResetGameSession();
            
        }
    }

    public void AddToScore (int pointsToAdd)
    {
            score += pointsToAdd;
            scoreText.text = score.ToString(); 
    }
    private void TakeLife()
    {
        playerLives --;

        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
        livesText.text = playerLives.ToString();

    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    void LoseSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(7);
        Destroy(gameObject);
    }

}