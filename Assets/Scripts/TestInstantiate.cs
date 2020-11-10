using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInstantiate : MonoBehaviour
{
    public GameObject image;
    List<GameObject> gameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(image, image.transform);
            gameObjects.Add(go);
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject go = gameObjects[gameObjects.Count-1];
            gameObjects.Remove(go);
            Destroy(go);

        }
    }
}
