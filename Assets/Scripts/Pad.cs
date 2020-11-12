using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
	float xPosition, xStartPosition, yPosition, yStartPosition, zPosition;
	public int redZonePad;
	public bool autoPlay;
	Ball ball;
	[SerializeField]
	GameManager gameManager;

	void Start()
	{
		ball = FindObjectOfType<Ball>();
		gameManager = FindObjectOfType<GameManager>();
		yStartPosition = transform.position.y;
		ToStartPosition();
	}

	public void ToStartPosition()
	{
		yPosition = yStartPosition;
		zPosition = 0;
	}

	void Update()
	{
		if (!gameManager.isPause)
		{
			xPosition = gameManager.cam.ScreenToWorldPoint(Input.mousePosition).x;
			//xPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
			xPosition = Mathf.Clamp(xPosition, -redZonePad, redZonePad);
			transform.position = new Vector3(xPosition, yPosition, zPosition);

			if (autoPlay)
			{
				xPosition = ball.transform.position.x;
				xPosition = Mathf.Clamp(xPosition, -redZonePad, redZonePad);
				transform.position = new Vector3(xPosition, yPosition, zPosition);
			}
		} //return


	}
}
