using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config parameters
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] Image[] hearts;

    //states
    [SerializeField] int pointsPerBlockDestroyed = 100;
    [SerializeField] int score = 0;
    [SerializeField] int playerLives = 3;

    //cached references
    [SerializeField] TextMeshProUGUI scoreText;

    // Awake is called before Start
    private void Awake()
    {
        //singleton pattern
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        playerLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void IncremementScore()
    {
        score += pointsPerBlockDestroyed;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void DecrementLife()
    {
        playerLives -= 1;
        DisplayPlayerLives();

        if (playerLives == 0)
        {
            FindObjectOfType<SceneLoader>().LoadGameOverScene();
        }
    }

    public void DisplayPlayerLives()
    {
        if(playerLives == 2)
        {
            hearts[2].GetComponent<Image>().color = Color.gray;
        }
        if (playerLives == 1)
        {
            hearts[1].GetComponent<Image>().color = Color.gray;
        }

        if (playerLives == 0)
        {
            hearts[0].GetComponent<Image>().color = Color.gray;
        }
            
    }
}
