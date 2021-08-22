using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // configuration parameters

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPaddlePos = 1f;
    [SerializeField] float maxPaddlePos = 15f;


    // cached references
    GameSession myGameSession;
    Ball myBall;


    // Start is called before the first frame update
    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minPaddlePos, maxPaddlePos);
        transform.position = paddlePos;
    }


    private float GetXPos()
    {
        if (myGameSession.IsAutoPlayEnabled())
        {
            return myBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
