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
	GameManager gameManager;
	LevelManager levelManager;
	public Sprite[] sprites;
	SpriteRenderer sr;
	int countHit;
	[Space]
	[Header("Шанс выпадания Pickup")]
	[Range (0, 100)]
	public int chanceOfDropPickups;
	[Header("Префабы Pickup")]
	public GameObject [] pickUps;
	Animator anim;




	void Start()
	{
		countHit = 0;
		sr = GetComponent<SpriteRenderer>();
		gameManager = FindObjectOfType<GameManager>();
		levelManager = FindObjectOfType<LevelManager>();
		//anim = GetComponent<Animator>();
		if (!isImmortal)
		{
			levelManager.BlockCreated();
		}

		if (isInvisible)
		{
			sr.enabled = false;
		}

	}

	void DestroyBlock()
	{
		gameManager.AddScore(score);
		levelManager.BlockDestroyed();
		Destroy(gameObject);
		CreatePicUp();
	}

	private void CreatePicUp()
	{
		int r = Random.Range(1, 101);

		if (r <= chanceOfDropPickups)
		{
			int i = Random.Range(0, pickUps.Length - 1);
			GameObject pickUpPrefab = pickUps[i];
			Instantiate(pickUpPrefab, transform.position, Quaternion.identity);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		countHit++;
		if (isInvisible)
		{
			sr.enabled = true;
			isInvisible = false;
			return;
		}

		if (isImmortal)
		{
			return;
		}

		if (countHit < countForDestroy)
		{
			if (countHit <= sprites.Length)
			{
				sr.sprite = sprites[countHit - 1]; // return
			}
			return;
		}
	
			DestroyBlock();		
	}

}
