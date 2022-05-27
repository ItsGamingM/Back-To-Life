using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    GameSession gameSession;
    
    void Awake() 
    {
        gameSession = FindObjectOfType<GameSession>();
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void GetMainMenu()
    {
        SceneManager.LoadScene(0);

        gameSession.playerLives = 10;
        gameSession.score = 0;
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        gameSession.playerLives = 10;
        gameSession.score = 0;
    }


}
