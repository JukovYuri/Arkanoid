using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusInfo : MonoBehaviour
{
    public Text bonusInfo;
    int totalBonus = 0;

    private void Awake()
    {
        GameManager[] bonusInfo= FindObjectsOfType<GameManager>();
        for (int i = 0; i < bonusInfo.Length; i++)
        {
            if (bonusInfo[i].gameObject != gameObject)
            {
                Destroy(gameObject);
                break;
            }
                
                
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SetBonusInfo(int bon)
    {
        totalBonus += bon;
        bonusInfo.text = totalBonus.ToString();
    }
}
