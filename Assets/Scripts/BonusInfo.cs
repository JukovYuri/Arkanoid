using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusInfo : MonoBehaviour
{
    public Text bonusInfo;
    int totalBonus = 0;

   public void SetBonusInfo(int bon)
    {
        totalBonus += bon;
        bonusInfo.text = totalBonus.ToString();
    }
}
