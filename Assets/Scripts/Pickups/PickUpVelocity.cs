using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpVelocity : MainPickUp
{
	[Header("кофф. изменения скорости")]
	[Range(0, 2)]
	public float multiples;

	public override void ApplyEffect()
	{
		base.ApplyEffect();

		Ball[] balls = FindObjectsOfType<Ball>();

		foreach (Ball item in balls)
		{
			item.MultiplySpeed(multiples);
		}

	}
}
