using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Ball : MonoBehaviour

{

	public int forceRange;

	float xPosition, yPosition, yStartPosition, zPosition;

	bool isStarted;

	Rigidbody2D rb;

	[SerializeField]

	Pad pad;

	[SerializeField]

	GameManager gameManager;



	void Start()

	{

		pad = FindObjectOfType<Pad>();

		gameManager = FindObjectOfType<GameManager>();

		rb = GetComponent<Rigidbody2D>();

		yStartPosition = transform.position.y;

		ToStartPosition();

	}



	public void ToStartPosition()

	{
		rb.velocity = Vector2.zero; //рассмотреть
		yPosition = yStartPosition;

		zPosition = 0;

		isStarted = false;

	}



	void Update()

	{

		if (!gameManager.isPause)

		{

			if (!isStarted)

			{

				StartBall();
			}
		}
	}

	void StartBall()

	{



		xPosition = pad.transform.position.x;

		transform.position = new Vector3(xPosition, yPosition, zPosition);

		if (Input.GetMouseButtonDown(0))

		{

			float x = Random.Range(-0.75f, 0.75f);

			Vector2 force = new Vector2(x, 1).normalized * forceRange;

			rb.velocity = force;

			isStarted = true;

		}

	}

}