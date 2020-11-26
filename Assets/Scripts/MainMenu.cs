using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text bestScoreText;
    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("bestRecord");
    }
}
