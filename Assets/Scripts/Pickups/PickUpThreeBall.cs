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
		ball = FindObjectOfType<Ball>();
		rb = ball.GetComponent<Rigidbody2D>();


		ball.isAfterPickUpThreeBall = true;
		base.ApplyEffect();

		for (int i = 1; i <= multiples; i++)
		{
			Ball ballClone = Instantiate(ball, ball.transform.position, ball.transform.rotation);
			AddMotion(ballClone);
		}
		ball.isAfterPickUpThreeBall = false;
	}

	void AddMotion (Ball b)
	{
		float x = Random.Range(-1f, 1f);
		float y = Random.Range(-1f, 1f);
		float magnitude = rb.velocity.magnitude;
		Vector2 norm = new Vector2(x, y).normalized;
		b.GetComponent<Rigidbody2D>().velocity = norm * magnitude; ;

		//b.StartVelocity();
		//b.GetComponent<Rigidbody2D>().velocity = rb.velocity;
		//b.yStartPosition = ball.yStartPosition;
	}
}
