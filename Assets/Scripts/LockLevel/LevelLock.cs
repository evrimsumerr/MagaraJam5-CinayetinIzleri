using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLock : MonoBehaviour
{
    public static LevelLock Instance;
    public List<bool> levelState;
    private void Awake()
    {
        Instance = this;
    }
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
                SceneManager.LoadScene(LevelClick.Instance.index + 3);
            }
        }
    }
}
