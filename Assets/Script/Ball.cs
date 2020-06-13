using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float axisX = 2f;
    [SerializeField] float axisY = 11f;
    [SerializeField] AudioClip[] BallSounds;
    [SerializeField] GameObject ballboom;
    [SerializeField] float randomfactor = 0.2f;


    //state
    Vector2 paddleToBallVector;
    private bool Grounded;
    public bool ballexistant = true;
    //Cached component references
    AudioSource myaudiosource;
    Rigidbody2D myRigidbody2D;
    GameStatus gameStatus;




    void Start()
    {
        Grounded = true;
        paddleToBallVector = transform.position - paddle1.transform.position;
        myaudiosource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    
    void Update()
    { if (Grounded == true)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) || gameStatus.IsAutoPlayEnabled() == true)
        {
            Grounded = false;
            myRigidbody2D.velocity = new Vector2(axisX, axisY);
        }
    }

    private void LockBallToPaddle()
    {
      
        
        
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocitytweakstage1 = new Vector2
        (UnityEngine.Random.Range(0f,randomfactor),
        UnityEngine.Random.Range(0f,randomfactor));

        Vector2 velocitytweakstage2 = new Vector2();

        if (UnityEngine.Random.Range(0, 2) == 1) { velocitytweakstage2 = velocitytweakstage1 * -1; } else { velocitytweakstage2 = velocitytweakstage1; }

        if (!Grounded) {
            AudioClip clip = BallSounds[UnityEngine.Random.Range( 0,BallSounds.Length)];
            myaudiosource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocitytweakstage2;// myRigidbody2D.velocity;
        }
    }

    public void Win()
    {
        ballexistant = false;

        Vector3 vector3 = new Vector3(transform.position.x,transform.position.y, transform.position.z);
        Destroy(gameObject);
    
     GameObject boomFX =   Instantiate(ballboom, transform.position = vector3,transform.rotation );
        Destroy(boomFX, 2f);
    }

    public void ReGround()
    {
        Grounded = true;

    }



}
