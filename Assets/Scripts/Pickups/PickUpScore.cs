using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScore : MainPickUp
{
	public override void ApplyEffect()
	{
		base.ApplyEffect();
		if (points < 0)
		{
			print("вычесть очки");
			return;
		}

		print("добавить очки");
	}
}
