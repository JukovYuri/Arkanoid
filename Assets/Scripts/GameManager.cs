using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

	int score;
	[HideInInspector]
	public bool isPause;
	[Header("количество жизней")]
	public int life;
	List<GameObject> imagesBallLife = new List<GameObject>();
	[Space]
	[Header("поле для вывода очков верхнее")]
	public Text textScore;
	[Space]
	[Header("UI объект для отображения паузы")]
	public Image imagePause;
	[Space]
	[Header("UI текст для отображения очков в окне «GameOver»")]
	public Text textScoreForGameOver;
	[Space]
	[Header("для отображения жизней мячами")]
	public GameObject imageBallLife;
	[Header("макс. количество отображаемых мячей")]
	public int balls;
	[Space]
	[Header("UI текст для отображения жизней цифрами")]
	public Text DigitLife;

	public Camera cam;

	private void Awake()
	{
			GameManager[] gameManagers = FindObjectsOfType<GameManager>();
			for (int i = 0; i < gameManagers.Length; i++)
			{
				if (gameManagers[i].gameObject != gameObject)
				{
					Destroy(gameObject);
					gameObject.SetActive(false);
					break;
				}
			}
	}

	void Start()
	{
		Cursor.visible = false;
		textScore.text = score.ToString();
		if (life > balls) { DrawDiditalLife(life); }
		else { DrawBallLife(life); }

		DontDestroyOnLoad(gameObject);
	}

	public void StartNewGame()
	{
		//textScoreForGameOver.transform.parent.gameObject.SetActive(false);
		SetPause();
		SceneManager.LoadScene(0);
		Destroy(gameObject);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SetPause();
		}
	}

	public void AddScore(int addScore)
	{
		score += addScore;
		textScore.text = score.ToString();
	}


	void DrawLife (int life)
	{

		if (life > balls)
		{
			DrawDiditalLife(life);
			return;
		}

		if (life <= 0)
		{
			imageBallLife.transform.parent.gameObject.SetActive(false);
			return;

		}
			DrawBallLife(life);
	}

	void DrawBallLife(int life)
	{
		DigitLife.transform.parent.gameObject.SetActive(false);
		imageBallLife.transform.parent.gameObject.SetActive(true);

		if (true)
		{

		}

		foreach (GameObject item in imagesBallLife)
		{
			Destroy(item);
		}
		imagesBallLife.Clear(); // проверить работу

		for (int i = 1; i <= life - 1; i++)
		{
			GameObject img = Instantiate(imageBallLife, imageBallLife.transform.parent);
			imagesBallLife.Add(img);
		}
	}

	void DrawDiditalLife(int life)
	{
		imageBallLife.transform.parent.gameObject.SetActive(false);
		DigitLife.transform.parent.gameObject.SetActive(true);
		DigitLife.text = $" <color=#FFF>X</color>  {life}";
	}

	public void AddLife()
	{
		life++;
		DrawLife(life);
	}



	public void SubLife()
	{
		life--;
		DrawLife(life);
		if (life <= 0)
		{
			GameOver();
		}
	}


	public void SetPause()
	{
		if (isPause)
		{
			isPause = false;
			Time.timeScale = 1F;
			Cursor.visible = false;
		}
		else
		{
			isPause = true;
			Time.timeScale = 0F;
			Cursor.visible = true;
		}

		imagePause.gameObject.SetActive(isPause);
	}

	void GameOver()
	{
		SetPause();
		imagePause.gameObject.SetActive(false);
		textScoreForGameOver.transform.parent.gameObject.SetActive(true);// TODO сделать одним окошком с паузой
		textScoreForGameOver.text = $"СЧЁТ: {score}";
		//TODO пауза 5 сек
		//TODO запуск autoplay
	}

	public void Exit()
	{
		Application.Quit();
	}

}
