using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBallScale : MainPickUp
{
	[Header ("величина изменения масштаба мяча")][Range(0,2)]
	public float multiples;

	public override void ApplyEffect()
	{
		base.ApplyEffect();
		Ball[] balls = FindObjectsOfType<Ball>();

		foreach (Ball item in balls)
		{
			item.transform.localScale *= multiples;
		}
	}
}
