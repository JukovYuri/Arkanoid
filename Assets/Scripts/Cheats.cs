using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cheats : MonoBehaviour
{
    public GameObject[] pickUps;
    Vector3 position;

    void Start()
    {
        position = new Vector3(0, 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(pickUps[0], position, Quaternion.identity);
            print("куку");
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(pickUps[1], position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(pickUps[2], position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(pickUps[3], position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Instantiate(pickUps[4], position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Instantiate(pickUps[5], position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Instantiate(pickUps[6], position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Instantiate(pickUps[7], position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Instantiate(pickUps[8], position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Instantiate(pickUps[9], position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            Instantiate(pickUps[10], position, Quaternion.identity);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            Instantiate(pickUps[11], position, Quaternion.identity);
            return;
        }
    }
}
