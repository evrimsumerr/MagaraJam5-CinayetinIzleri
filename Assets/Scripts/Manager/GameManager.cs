using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int levelIndex = 1;
    public int timer;
    bool isFinished;
    public bool isRunning = true;
    private void Awake()
    {
        Instance = this;
    }
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
            GameManager.Instance.isRunning = false;
            UIManager.Instance.SettingMenuOpen();
            //StartCoroutine(Stop());
            Time.timeScale = 0;
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

            //if (isRunning)
            //{
            //    //yield return new WaitForSeconds(1);
            //    timer--;
            //}
            //yield return new WaitForSeconds(1);
            //timer--;
        }
        if (timer == 0)
        {
            isFinished = true;
        }
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1.25f);
        Time.timeScale = 0;
    }
}
