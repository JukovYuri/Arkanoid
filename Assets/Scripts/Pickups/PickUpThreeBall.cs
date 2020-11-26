using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThreeBall : MainPickUp
{
	public int multiples;
	Ball ball;

	public override void ApplyEffect()
	{
		ball = FindObjectOfType<Ball>();

		base.ApplyEffect();

		for (int i = 0; i <= multiples; i++)
		{
			ball.Duplicate();
		}

	}
}
