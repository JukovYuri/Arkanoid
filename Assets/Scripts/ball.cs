using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	float xPosition, yPosition, zPosition;
	Rigidbody2D rb;
	public Pad pad;
	public int forceRange;
	bool isStarted;

	void Start()
	{
		yPosition = transform.position.y;
		zPosition = 0;
		rb = GetComponent<Rigidbody2D>();

	}
	void Update()
	{
		if (!isStarted)
		{
			StartBall();
		}
	}

	void StartBall()
	{
		xPosition = pad.transform.position.x;
		transform.position = new Vector3(xPosition, yPosition, zPosition);
		if (Input.GetMouseButtonDown(0))
		{
			float x = Random.Range(-0.75f, 0.75f);
			float y = Mathf.Sqrt(1 - x * x);
			Vector2 force = new Vector2(x, y);
			rb.AddForce(force * forceRange);
			isStarted = true;
		}
	}
}






















//public class ball : MonoBehaviour
//{
//	public float speed;
//	public Rigidbody2D rb;
//	bool isStarted;
//	public Pad pad;
//	float yPosition;

//	void Start()
//	{
//		yPosition = transform.position.y;
//	}

//	private void Update()
//	{
//		if (isStarted)
//		{
//			//мяч запущен, ничего не делаем
//		}
//		else
//		{
//			//	мяч запущен
//			Vector3 padPosition = pad.transform.position;
//			Vector3 ballNewPozition = new Vector3(padPosition.x, yPosition, 0);
//			transform.position = ballNewPozition;

//			//	проверить кнопку мыши
//			if (Input.GetMouseButtonDown(0))
//			{
//				StartBall();
//			}
//		}

//		print(rb.velocity);
//	}

//	void StartBall()
//	{
//		Vector2 force = new Vector2(1, 1) * speed;
//		rb.AddForce(force);
//		isStarted = true;
//	}




//	private void OnCollisionEnter2D(Collision2D collision)
//	{
//		print("enter!");
//	}

//	private void OnCollisionExit2D(Collision2D collision)
//	{
//		print("exit!");
//	}

//	private void OnTriggerEnter2D(Collider2D collision)
//	{
//		print("trigger enter!");
//	}

//	private void OnTriggerExit2D(Collider2D collision)
//	{
//		print("trigger exit!");
//	}
