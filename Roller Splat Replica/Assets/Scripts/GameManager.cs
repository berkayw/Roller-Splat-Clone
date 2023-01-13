using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] grounds;
    public float groundsNumber;
    private int currentLevel;
    
    
    
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        
    }

    void Update()
    {
        groundsNumber = grounds.Length;
    }

    public void LevelUpdate()
    {
        if (currentLevel == 1)
        {
            currentLevel = -1;
        }
        SceneManager.LoadScene(currentLevel+1); //Current Scene + 1
    }
}
