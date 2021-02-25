using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // initialise
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 initialVelocity = new Vector2(2,15);
    [SerializeField] AudioClip[] ballSounds;

    // states
    Vector2 paddleToBallVector;
    private bool hasLaunched = false;

    // cached references
    AudioSource myAudioSource;
    Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = this.transform.position - paddle1.transform.position;

        myAudioSource = GetComponent <AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLaunched)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick(); 
        }

    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasLaunched = true;
            rigidBody2D.velocity = initialVelocity;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        this.transform.position = paddlePos + paddleToBallVector;
    }

    public void ResetBall()
    {
        hasLaunched = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasLaunched)
        {
            AudioClip audioclip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            this.myAudioSource.PlayOneShot(audioclip,0.5f);
        }

     
    }

    private void VelocityTweak()
    {
        if (rigidBody2D.velocity.x > -0.5 && rigidBody2D.velocity.x < 0.5)
        {
            Debug.Log("velocity tweak x");
            rigidBody2D.velocity += new Vector2(0.5f, 0);
        }

        if (rigidBody2D.velocity.y > -0.5 && rigidBody2D.velocity.y < 0.5)
        {
            Debug.Log("velocity tweak y");
            rigidBody2D.velocity += new Vector2(0, 0.5f);
        }
    }
}
