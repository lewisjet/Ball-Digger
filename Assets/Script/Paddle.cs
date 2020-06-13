using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float Width = 16f;
    [SerializeField] float minX = 1f,maxX = 15f;

    //cached reference
    GameStatus gameStatus;
    Ball ball;
    PauseMenuActivator pauseMenuActivator;
    CreditLoader creditLoader;
    bool wintrue;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
        pauseMenuActivator = FindObjectOfType<PauseMenuActivator>();
        creditLoader = FindObjectOfType<CreditLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (creditLoader != null ) { if (creditLoader.win) { wintrue = true; } }





        if (pauseMenuActivator.gamePaused == false && !wintrue )
        {
            if (tag != "Core")
            {

                float MousePosInUnits = Input.mousePosition.x / Screen.width * Width;

                float PaddleClampedPos = Mathf.Clamp(GetXpos(), minX, maxX);

                Vector2 PaddlePos = new Vector2(PaddleClampedPos, transform.position.y);
                transform.position = PaddlePos;
            }
            else
            {
                float MousePosInUnits = (Input.mousePosition.x) / Screen.width * Width;

                float PaddleClampedPos = Mathf.Clamp(GetXpos(), minX, maxX);

                Vector2 PaddlePos = new Vector2((PaddleClampedPos), transform.position.y);
                transform.position = PaddlePos;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameStatus>().paddlehit();
       
    }

    private float GetXpos()
    {
        if (gameStatus.IsAutoPlayEnabled() && ball.ballexistant == true )
        {
            return ball.transform.position.x;
        }
        else
        { if (tag != "Core")
            {
                return Input.mousePosition.x  / Screen.width * Width;
            }
        else {return (Input.mousePosition.x * -1 ) / Screen.width * Width; }
        }
    }





}
