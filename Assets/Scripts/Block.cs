using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Block : MonoBehaviour
{
    public int countForDestroy;
    public int bonus;
    public BonusInfo bonusInfo;
    public Sprite[] sprites;
    SpriteRenderer sr;
    int countHit;



    void Start()
    {
        countHit = 0;
        bonusInfo.SetBonusInfo(0);
        sr = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        countHit++;
        if (countHit < countForDestroy)
        {
            if (countHit <= sprites.Length)
            {
                sr.sprite = sprites[countHit-1];               
            }
        }

        else
        {
            bonusInfo.SetBonusInfo(bonus);
            Destroy(gameObject);
        }
    }


}
