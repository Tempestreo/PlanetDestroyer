using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("MusicVolume", 1);
        if (!PlayerPrefs.HasKey("Level1"))
        {
            PlayerPrefs.SetInt("Level1", 1);
            PlayerPrefs.SetInt("Level2", 0);
            PlayerPrefs.SetInt("Level3", 0);
            PlayerPrefs.SetInt("Level4", 0);
            PlayerPrefs.SetInt("Level5", 0);
            PlayerPrefs.SetInt("Level6", 0);
            PlayerPrefs.SetInt("Level7", 0);
            PlayerPrefs.SetInt("Level8", 0);
            PlayerPrefs.SetInt("Level9", 0);
            PlayerPrefs.SetInt("Level10", 0);

            PlayerPrefs.SetFloat("MusicVolume", 1);
        }
    }
    
}
