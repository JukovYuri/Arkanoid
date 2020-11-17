using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThreeBall : MainPickUp
{
	public int multiples;
	Ball ball;
	Rigidbody2D rb;

	public override void ApplyEffect()
	{
		print("троилка");
		base.ApplyEffect();
		ball = FindObjectOfType<Ball>();
		rb = ball.GetComponent<Rigidbody2D>();

		ball.isAfterPickUpThreeBall = true;

		for (int i = 1; i <= multiples; i++)
		{
			Ball ballClone = Instantiate(ball, ball.transform.position, ball.transform.rotation);
			AddMotion(ballClone);
		}
		ball.isAfterPickUpThreeBall = false;
	}

	void AddMotion (Ball b)
	{
		ball.StartVelocity(b.GetComponent<Rigidbody2D>());
		b.yStartPosition = ball.yStartPosition;
	}
}
