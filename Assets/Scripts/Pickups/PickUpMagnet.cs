using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMagnet : MainPickUp
{
	public override void ApplyEffect()
	{
		base.ApplyEffect();
		Ball [] balls = FindObjectsOfType<Ball>();	
		foreach (Ball item in balls)
		{
			item.ActivateMagnet();
		}
	}

}
