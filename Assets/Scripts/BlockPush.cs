using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPush : MonoBehaviour
{
	Vector2 startPosition;
	Vector2 pushPosition;

	public float speed;
	public float delta;
	bool isPushPosition;
	bool isToFinish;
	bool isCollisionRight, isCollisionLeft, isCollisionTop, isCollisionBottom;

	Collider2D coll;
	float sizeX;
	float sizeY;


	private void Start()
	{
		startPosition = transform.position;
		pushPosition = startPosition;
		coll = GetComponent<Collider2D>();
		sizeX = coll.bounds.size.x;
		sizeY = coll.bounds.size.y;
		pushPosition.y = startPosition.y + delta;
	}


	private void Update()
	{
		if (isCollisionRight)
		{
			pushPosition.x = startPosition.x - delta;
			Push(pushPosition);
			return;
		}

		if (isCollisionLeft)
		{
			pushPosition.x = startPosition.x + delta;
			Push(pushPosition);
			return;
		}

		if (isCollisionTop)
		{
			pushPosition.y = startPosition.y - delta;
			Push(pushPosition);
			return;
		}

		if (isCollisionBottom)
		{
			pushPosition.y = startPosition.y + delta;
			Push(pushPosition);
			return;

		}
	}

	public void Push(Vector2 position)
	{
		if (isToFinish && !isPushPosition)
		{
			isCollisionRight = false;
			isCollisionLeft = false;
			isCollisionBottom = false;
			isCollisionTop = false;
			return;
		}

		if (Vector2.Distance(transform.position, pushPosition) <= 0)
		{
			isPushPosition = true;
		}

		if (Vector2.Distance(transform.position, startPosition) <= 0)
		{
			isPushPosition = false;
		}

		if (isPushPosition)
		{
			transform.position = Vector2.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
			isToFinish = true;
		}
		else
		{
			transform.position = Vector2.MoveTowards(transform.position, pushPosition, speed * Time.deltaTime);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		isToFinish = false;
		isPushPosition = false;

		if (collision.gameObject.CompareTag("Ball"))
		{
			Vector2 colPosition = collision.gameObject.transform.position;

			if (colPosition.x >= (startPosition.x + sizeX / 2))
			{
				isCollisionRight = true;
				return;
			}

			if (colPosition.x <= (startPosition.x - sizeX / 2))
			{
				isCollisionLeft = true;
				return;
			}

			if (colPosition.y <= (startPosition.y - sizeY / 2))
			{
				isCollisionBottom = true;
				return;
			}

			if (colPosition.y >= (startPosition.y + sizeY / 2))
			{
				isCollisionTop = true;
				return;
			}
		}
	}
}