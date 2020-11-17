using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPadScale : MainPickUp
{
	public bool isSmaller;
	public float multiples;
	public override void ApplyEffect()
	{
		base.ApplyEffect();
		Pad pad = FindObjectOfType<Pad>();

		if (isSmaller)
		{
			pad.transform.localScale = new Vector3((1/multiples), 1, 1);
			print("уменьшить платформу");
			return;
		}

		pad.transform.localScale = new Vector3(multiples, 1, 1);
		print("увеличить платформу");
	}
}
