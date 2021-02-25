using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] GameSession gameStatus;

    void Start()
    {
       gameStatus = FindObjectOfType<GameSession>();
    }
    

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        gameStatus.ResetGame();
       
        SceneManager.LoadScene(0);
        
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
