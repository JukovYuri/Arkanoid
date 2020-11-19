using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    public Pad pad;

    public Ball ball;
    [SerializeField]
    int countOfBall = 0;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        pad = FindObjectOfType<Pad>();
        ball = FindObjectOfType<Ball>();
    }

    public void BallCreated()
    {
        ++countOfBall;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            if (countOfBall > 1 )
            {
                --countOfBall;           
                return;
            }

            gameManager.SubLife();
            pad.ToStartPosition();
            ball.ToStartPosition();
            return;
        }

        Destroy(collision.gameObject);
    }
}
