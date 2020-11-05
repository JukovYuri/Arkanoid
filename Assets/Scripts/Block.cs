using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Block : MonoBehaviour
{
	[Tooltip("Количество попаданий в блок до разрушения")]
	public int countForDestroy;
	[Tooltip("Количество очков за уничтожение блока")]
	public int bonus;
	BonusInfo bonusInfo;
	LevelManager levelManager;
	public Sprite[] sprites;
	SpriteRenderer sr;
	int countHit;
	bool isCollision;



	void Start()
	{
		countHit = 0;
		sr = GetComponent<SpriteRenderer>();
		bonusInfo = FindObjectOfType<BonusInfo>();
		levelManager = FindObjectOfType<LevelManager>();

		levelManager.BlockCreated();
	}

	void Update()
	{
		if (isCollision)
		{
			TranslateBlock();
		}
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		isCollision = true;
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
			bonusInfo.SetBonusInfo(bonus);
			levelManager.BlockDestroyed();
			Destroy(gameObject);
		}
	}

	void TranslateBlock()
	{
		transform.Translate(Time.deltaTime, 0, 0);
		isCollision = false;
		print("куку");
	}
}
