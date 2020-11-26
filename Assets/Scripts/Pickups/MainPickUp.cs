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

		//Ball[] balls = FindObjectsOfType<Ball>();
		//Ball ball = FindObjectOfType<Ball>();

		//Pad pad = FindObjectOfType<Pad>();

		//// платформу в норм размер
		//pad.transform.localScale = Vector3.one;

		//if (ball.isAfterPickUpThreeBall)
		//{
		//	return;
		//}

		//foreach (Ball item in balls)
		//{
		//	// мячи в норм размер
		//	item.transform.localScale = Vector3.one;

		//	// магниты в мячах отключить
		//	item.DeactivateMagnet();

		//	// скорость в норм
		//	item.GetComponent<Rigidbody2D>().velocity = item.GetComponent<Rigidbody2D>().velocity.normalized * item.speed;
		//}
	}

	public virtual void ApplyEffect()
	{
		GameManager gameManager = FindObjectOfType<GameManager>();
		gameManager.AddScore(points);

		ClearLastEffects();
	}

}
