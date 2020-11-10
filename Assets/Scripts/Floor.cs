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

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        pad = FindObjectOfType<Pad>();
        print($"это pad - {pad}");
        ball = FindObjectOfType<Ball>();
        print($"это ball - {ball}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OnTrigger!");
        gameManager.SubLife();
        pad.ToStartPosition();
        ball.ToStartPosition();
    }
}
