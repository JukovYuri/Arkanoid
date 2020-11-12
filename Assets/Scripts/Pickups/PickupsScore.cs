using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsScore : MonoBehaviour
{
	public int points;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Pad"))
		{
			ApplyEffect();
			Destroy(gameObject);
		}
	}

	void ApplyEffect()
	{
		GameManager gameManager = FindObjectOfType<GameManager>();
		gameManager.AddScore(points);
	}




}
