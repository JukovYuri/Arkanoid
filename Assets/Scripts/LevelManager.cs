using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public int blocksCount;

    private void Start()
    {
        //Block[] allBlock = FindObjectsOfType<Block>();
        //blocksCount = allBlock.Length;
    }

    public void BlockCreated()
    {
        blocksCount++;
    }

    public void BlockDestroyed()
    {
        blocksCount--;
        if (blocksCount <= 0)
        {
            LoadLevel();
        }
    }

    public void LoadLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (index == 1)
        {
            SceneManager.LoadScene(0);
        }

        else
        {
            SceneManager.LoadScene(index + 1);
        } 
    }

}
