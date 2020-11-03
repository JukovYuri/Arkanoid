using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    float xPosition, yPosition, zPosition;
    public int redZonePad;

    void Start()
    {
        yPosition = transform.position.y;
        zPosition = 0;
    }

    void Update()
    {
        xPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if (xPosition > redZonePad)
        {
            xPosition = redZonePad;
        }

        else if (xPosition < -redZonePad)
        {
            xPosition = -redZonePad;
        }
        transform.position = new Vector3(xPosition, yPosition, zPosition);

    }
}










//Vector3 mousePixelPosition = Input.mousePosition;
//Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);

//Vector3 padNewPozition = mouseWorldPosition;
//padNewPozition.z = 0;
//padNewPozition.y = yPosition;

////Vector3 padNewPozition = Vector3(mouseWorldPosition.x, yPosition, 0);

//transform.position = padNewPozition;