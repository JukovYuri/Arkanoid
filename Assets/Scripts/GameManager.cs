using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isPause;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPause)
            {
                Time.timeScale = 1F;
                isPause = false;
            }
            else
            {
                Time.timeScale = 0F;
                isPause = true;
            }



        }


    }
}
