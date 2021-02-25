using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;
    SceneLoader sceneloader;
    GameSession gameSession;


    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }

    public void BlockDestroyed()
    {
        DecrementBreakableBlocks();
        gameSession.IncremementScore();
    }

    public void IncremementBlocks()
    {
        breakableBlocks++; 
    }  

    public void DecrementBreakableBlocks()
    {
        breakableBlocks--;

        HasWon();
    }

    private void HasWon()
    {
        if(breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
