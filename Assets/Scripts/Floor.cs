using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour
{
	[SerializeField] GameManager gameManager;
	[SerializeField] Ball ball;
	Pad pad;
	[SerializeField] int countOfBall = 0;

	private void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
		pad = FindObjectOfType<Pad>();
	}

	public void BallCreated()
	{
		++countOfBall;
	}

	public void OnTriggerEnter2D(Collider2D collision) // мяч триггерит пол
	{

		if (collision.gameObject.CompareTag("Ball"))
		{
			if (countOfBall > 1)
			{
				--countOfBall;
			}
			else
			{
				gameManager.SubLife();
				pad.ToStartPosition();
				ball = FindObjectOfType<Ball>();
				//ball = collision.gameObject.GetComponent<Ball>();
				ball.ToStartPosition();
				print(ball); // выводит имя мяча, все ок
				return;
			}
		}

		Destroy(collision.gameObject);
	}
}
