using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ball : MonoBehaviour
{

	public float speed;
	float xPosition, xDelta, yPosition, yStartPosition, zPosition;
	bool isStarted;
	bool isMagnet;
	Rigidbody2D rb;
	AudioSource audioSource;
	public AudioClip explosionSound;
	Pad pad;
	GameManager gameManager;
	Floor floor;


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
	}
	void Start()

	{
		zPosition = 0F;

		floor = FindObjectOfType<Floor>();
		floor.BallCreated();

		pad = FindObjectOfType<Pad>();
		gameManager = FindObjectOfType<GameManager>();

		yStartPosition = -7.19f; //как исправить?
		yPosition = yStartPosition;
	}

	void Update()
	{
		if (gameManager.isPause)
		{
			return;
		}

		if (isStarted)
		{
			return;
		}

		else
		{
			StartBall();
		}
	}

	void StartBall()
	{
		xPosition = pad.transform.position.x + xDelta;
		transform.position = new Vector3(xPosition, yPosition, zPosition);
		if (Input.GetMouseButtonDown(0))
		{
			StartVelocity();
		}
	}

	public void StartVelocity()
	{
		//float x = Random.Range(-0.75f, 0.75f);
		float x = Random.Range(0, 0);
		Vector2 force = new Vector2(x, 1).normalized * speed;
		rb.velocity = force; //рассмотреть скорость
		isStarted = true;
	}

	public void ToStartPosition()
	{
		print(rb.gameObject.name + "ToStartPosition");
		rb.velocity = Vector2.zero;
		isStarted = false;
	}


	public void ActivateExplosion()
	{
		audioSource.clip = explosionSound;
	}
	public void ActivateMagnet()
	{
		isMagnet = true;
	}

	public void DeactivateMagnet()
	{
		isMagnet = false;
	}

	public void Duplicate()
	{
		Ball newBall = Instantiate(this);
		newBall.StartVelocity();
		newBall.speed = speed;
	}

	public void MultiplySpeed(float multiply)
	{
		speed *= multiply;
		rb.velocity = rb.velocity.normalized * speed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		audioSource.Play();
		if (isMagnet && collision.gameObject.CompareTag("Pad"))
		{
			xDelta = transform.position.x - pad.transform.position.x;
			yPosition = transform.position.y;
			ToStartPosition();
		}
	}

}