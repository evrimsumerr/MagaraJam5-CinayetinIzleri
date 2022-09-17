using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GenericSingleton<GameManager>
{
    public int levelIndex = 1;
    bool isFinished;
    void Start()
    {

    }


    void Update()
    {
        if (isFinished)
        {
            LevelLock.Instance.levelState[SceneManager.GetActiveScene().buildIndex - 1] = true;
        }
    }
}
