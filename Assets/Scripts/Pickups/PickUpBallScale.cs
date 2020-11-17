using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBallScale : MainPickUp
{
	public bool isSmaller;
	public float multiples;

	public override void ApplyEffect()
	{
		base.ApplyEffect();
		Ball[] balls = FindObjectsOfType<Ball>();

		foreach (Ball item in balls)
		{

			if (isSmaller)
			{
				item.transform.localScale /= multiples;
			}

			else
			{
				item.transform.localScale *= multiples;
			}

		}
	}
}
