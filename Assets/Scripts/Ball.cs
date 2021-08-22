using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{

    // configuration parameters
    [SerializeField] Paddle paddle;
    [SerializeField] float minPush = 2f;
    [SerializeField] float maxPush = 13f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;


    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;


    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;



    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted != true)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(minPush, maxPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTwek = new Vector2
            (UnityEngine.Random.Range(0f, randomFactor), 
            UnityEngine.Random.Range(0f, randomFactor));
        if (hasStarted)  // same is (hasStarted == 0)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTwek;
        }
    }
}
