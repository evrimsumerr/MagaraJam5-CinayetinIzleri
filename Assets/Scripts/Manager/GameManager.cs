using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GenericSingleton<GameManager>
{
    public int levelIndex = 1;
    public int timer;
    bool isFinished;
    void Start()
    {
        timer = PlayerPrefs.GetInt("Time");
        StartCoroutine(Timer());
        SoundManager.Instance.PlayGeneralSound();
    }


    void Update()
    {
        if (isFinished)
        {
            LevelLock.Instance.levelState[SceneManager.GetActiveScene().buildIndex - 1] = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.SettingMenuOpen();
            //Cursor.visible = true;
        }
    }
    
    //timer coroutine
    IEnumerator Timer()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }
        if (timer == 0)
        {
            isFinished = true;
        }
    }
    
}
