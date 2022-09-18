using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetString("First") == "True")
        {
            SceneManager.LoadScene(2);
        }
    }
}
