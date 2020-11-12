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
        ball = FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.CompareTag(""))
        {
            
        }


        gameManager.SubLife();
        pad.ToStartPosition();
        ball.ToStartPosition();
    }
}
