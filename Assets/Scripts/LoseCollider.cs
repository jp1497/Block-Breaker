using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour

{
    GameSession gameSession;
    Ball ball;

    private void Start()
    {
       ball = FindObjectOfType<Ball>();
       gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameSession.DecrementLife();
        ball.ResetBall();
    }
}
