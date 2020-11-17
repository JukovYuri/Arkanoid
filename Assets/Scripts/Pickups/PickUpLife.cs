using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLife : MainPickUp
{
	public bool isSubtract;
	public override void ApplyEffect()
	{
		base.ApplyEffect();
		GameManager gameManager = FindObjectOfType<GameManager>();

		if (isSubtract)
		{
			gameManager.SubLife();
			print("вычесть жизнь");
			return;
		}

		gameManager.AddLife();
		print("добавить жизнь");
	}
}
