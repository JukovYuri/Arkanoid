using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPickUp : MonoBehaviour
{
	public int points;


	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Pad"))
		{
			ApplyEffect();
			Destroy(gameObject);
		}
	}

	void ClearLastEffects()
	{

		Ball[] balls = FindObjectsOfType<Ball>();

		Pad pad = FindObjectOfType<Pad>();

		// платформу в норм размер
		pad.transform.localScale = Vector3.one;

		if (true)
		{

		}

		foreach (Ball item in balls)
		{
			// мячи в норм размер
			item.transform.localScale = Vector3.one;

			// магниты в мячах отключить
			item.isCollisionWithPadAfterPickUpMagnet = false;

			// скорость в норм
			item.GetComponent<Rigidbody2D>().velocity = item.GetComponent<Rigidbody2D>().velocity.normalized * item.forceRange;
		}
	}

	public virtual void ApplyEffect()
	{
		GameManager gameManager = FindObjectOfType<GameManager>();
		gameManager.AddScore(points);

		ClearLastEffects();
	}

}
