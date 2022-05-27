using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    GameSession gameSession;
    [SerializeField] GameObject exitUnlockedParticles;
    [SerializeField] bool isDoorUnlocked = false;

    [SerializeField] float loadDelay = 1f;
    public int numberOfFragmentNeeded = 0;


    void Awake() 
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
         if (other.tag == "Player" &&  gameSession.score == numberOfFragmentNeeded)
        {
            StartCoroutine (LoadNextLevel());
        }
    }
    void Update() 
    {
        if (isDoorUnlocked == false && gameSession.score == numberOfFragmentNeeded)
        {
            Instantiate(exitUnlockedParticles,gameObject.transform.position, transform.rotation);
            isDoorUnlocked = true;
        }
    }
    
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(loadDelay);
        
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = CurrentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings )
        {
            nextSceneIndex = 0;
        }
        FindObjectOfType<ScenePersist>().ResetScenePersist();

        SceneManager.LoadScene(nextSceneIndex);
    }
}
