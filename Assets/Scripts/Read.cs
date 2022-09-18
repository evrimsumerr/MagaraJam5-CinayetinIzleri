using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Read : MonoBehaviour
{
    public static Read instance;
    public GameObject readObject;
    public Image text;
    bool firstScreen;
    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.GetString("First") == "True")
        {
            SceneManager.LoadScene(2);
        }
    }
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("First"));
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            firstScreen = true;
            PlayerPrefs.SetString("First", firstScreen.ToString());
        }
        Cursor.visible = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sadas");
        if (other.CompareTag("Level"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
