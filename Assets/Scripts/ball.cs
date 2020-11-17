using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ball : MonoBehaviour
{

	public int forceRange;
	float xPosition, xPositionAfterPickUpMagnet, yPosition, zPosition;

	public float yStartPosition;
	public bool isStarted;
	public bool isCollisionWithPadAfterPickUpMagnet;
	public bool isAfterPickUpThreeBall;
	Rigidbody2D rb;
	Pad pad;
	GameManager gameManager;
	Floor floor;
	Ball ball;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}



	void Start()

	{

		floor = FindObjectOfType<Floor>();
		floor.BallCreated();

		pad = FindObjectOfType<Pad>();
		gameManager = FindObjectOfType<GameManager>();
		


		if (isAfterPickUpThreeBall)
		{
			isStarted = true;
			return;
		}

		yStartPosition = transform.position.y;
		ToStartPosition();

	}



	public void ToStartPosition()

	{
		rb.velocity = Vector2.zero; //рассмотреть скорость
		yPosition = yStartPosition;
		zPosition = 0;
		isStarted = false;
	}



	void Update()
	{
		print($"скорость --- {rb.velocity.magnitude}");
		if (gameManager.isPause)
		{
			return;
		}

		if (isStarted)
		{
			return;
		}

		StartBall();

	}

	void StartBall()
	{
		xPosition = pad.transform.position.x;
		transform.position = new Vector3(xPosition, yPosition, zPosition);
		if (Input.GetMouseButtonDown(0))
		{
			StartVelocity();
			isStarted = true;
		}

	}

	public void StartVelocity()
	{
		float x = Random.Range(-0.75f, 0.75f);
		Vector2 force = new Vector2(x, 1).normalized * forceRange;
		rb.velocity = force; //рассмотреть скорость
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.CompareTag("Pad"))
		{
			if (isCollisionWithPadAfterPickUpMagnet)
			{
				ToStartPosition();
			}

		}
	}

}