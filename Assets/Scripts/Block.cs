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
	[Header("Невидимость")]
	public bool isInvisible;
	[Header("Взрывной")]
	public bool explosive;
	public float explosionRadius;

	[Space]
	public Sprite[] sprites;

	[Space]
	[Header("Шанс выпадания Pickup")]
	[Range (0, 100)]
	public int chanceOfDropPickups;
	[Header("Префабы Pickup")]
	public GameObject [] pickUps;
	[Header("Префабы Рarticles")]
	public GameObject particles;

	GameManager gameManager;
	LevelManager levelManager;
	SpriteRenderer sr;

	int countHit;

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

	public void DestroyBlock()
	{
		gameManager.AddScore(score);
		levelManager.BlockDestroyed();
		if (particles)
		{
			Instantiate(particles, transform.position, Quaternion.identity);
		}
		
		Destroy(gameObject);
		CreatePickUp();
	}

	private void CreatePickUp()
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

		if (explosive)
		{
			Explode();
		}
		
		DestroyBlock();		
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}

	private void Explode()
	{
		int layerMask = LayerMask.GetMask("Block");
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, layerMask);

		foreach (Collider2D item in colliders)
		{
			Block block = item.GetComponent<Block>();
			if (block == null)
			{
				Destroy(item.gameObject);
			}
			else
			{
				block.DestroyBlock();
			}

		}
	}

}
