using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLock : GenericSingleton<LevelLock>
{
    public List<bool> levelState;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        for (int i = 0; i < levelState.Count; i++)
        {
            if (i == LevelClick.Instance.index)
            {
                SceneManager.LoadScene(LevelClick.Instance.index + 1);
            }
        }
    }
}
