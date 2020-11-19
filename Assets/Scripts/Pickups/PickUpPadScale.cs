using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPadScale : MainPickUp
{
	[Header("величина изменения ширины Pad")][Range(0, 2)]
	public float multiples;
	public override void ApplyEffect()
	{
		base.ApplyEffect();
		Pad pad = FindObjectOfType<Pad>();
		pad.transform.localScale = new Vector3(multiples, 1, 1);
	}
}
