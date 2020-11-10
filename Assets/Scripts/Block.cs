using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Block : MonoBehaviour
{
	[Header("Количество попаданий в блок до разрушения")]
	public int countForDestroy;
	[Space]
	[Header("Количество очков за уничтожение блока")]
	public int score;
	[Space]
	[Header("Неразрушаемость")]
	public bool isImmortal;
	public bool isInvisible;
	[SerializeField]
	GameManager gameManager;
	[SerializeField]
	LevelManager levelManager;
	public Sprite[] sprites;
	SpriteRenderer sr;
	int countHit;



	void Start()
	{
		countHit = 0;
		sr = GetComponent<SpriteRenderer>();
		gameManager = FindObjectOfType<GameManager>();
		levelManager = FindObjectOfType<LevelManager>();
		if (!isImmortal)
		{
			levelManager.BlockCreated();
		}

		if (isInvisible)
		{
			sr.enabled = false;
		}

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (isInvisible)
		{
			sr.enabled = true;
			isInvisible = false;
		}
		else if (!isImmortal)
		{
			countHit++;
			if (countHit < countForDestroy)
			{
				if (countHit <= sprites.Length)
				{
					sr.sprite = sprites[countHit - 1];
				}
			}

			else
			{
				gameManager.AddScore(score);
				levelManager.BlockDestroyed();
				Destroy(gameObject);
			}
		}
	}
}
