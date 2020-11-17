using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpVelocity : MainPickUp
{
	public float multiples;
	public bool isSlower;

	public override void ApplyEffect()
	{
		
		base.ApplyEffect();

		Ball[] balls = FindObjectsOfType<Ball>();

		foreach (Ball item in balls)
		{
			Rigidbody2D rb = item.GetComponent<Rigidbody2D>();

			if (isSlower)
			{
				rb.velocity /= multiples;
				print("уменьшить скорость");
			}
			else
			{
				rb.velocity *= multiples;
				print("увеличить скорость");
			}		
		}

	}
}
