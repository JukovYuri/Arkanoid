using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    float yPosition;

    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        Vector3 mousePixelPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);

        Vector3 padNewPozition = mouseWorldPosition;
        padNewPozition.z = 0;
        padNewPozition.y = yPosition;

        //Vector3 padNewPozition = Vector3(mouseWorldPosition.x, yPosition, 0);

        transform.position = padNewPozition;


    }
}
