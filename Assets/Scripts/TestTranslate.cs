using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestTranslate : MonoBehaviour
{
    float PosY;
    float newPosY;
    int velocity = 5;

    bool isCollision;
    // Start is called before the first frame update
    void Start()
    {
        PosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, velocity * Time.deltaTime, 0);

        if (transform.position.y > 5)
        {
            velocity = -velocity;
        }
    }

}
