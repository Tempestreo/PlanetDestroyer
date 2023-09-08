using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public bool isStarted;

    #region components

    [SerializeField] AudioSource audio;

    [SerializeField] GameObject WinLvlPnl;
    [SerializeField] GameObject LoseLvlPnl;
    [SerializeField] GameObject StartLvlPnl;

    [SerializeField] GameObject LoseCanvas;
    [SerializeField] GameObject StartMenuCanvas;
    [SerializeField] GameObject WinCanvas;
    [SerializeField] GameObject AudioSettings;
    [SerializeField] GameObject VideoSettings;
    [SerializeField] GameObject MenuSettings;
    [SerializeField] GameObject MenuMain;
    [SerializeField] GameObject LocalMenuManager;

    [SerializeField] Slider QualitySlide;
    [SerializeField] Slider AudioSlider;

    #endregion

    private void Awake()
    {
        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
        isStarted = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LocalMenuManager.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void SceneManagment(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void WinPanel()
    {
        StartCoroutine(DelayWin());
    }
    public void LosePanel()
    {
        StartCoroutine(DelayLose());
    }
    public void SetSettingsActive()
    {
        MenuSettings.SetActive(true);
        MenuMain.SetActive(false);
    }
    public void ResumeGame()
    {
        LocalMenuManager.SetActive(false);
        Time.timeScale = 1;
    }
    public void LevelCheck()
    {
        for (int i = 1; i < 11; i++)
        {
            if (PlayerPrefs.GetInt("Level" + i.ToString()) == 0)
            {
                WinLvlPnl.transform.GetChild(i - 1).GetComponent<Button>().interactable = false;
                LoseLvlPnl.transform.GetChild(i - 1).GetComponent<Button>().interactable = false;
                StartLvlPnl.transform.GetChild(i - 1).GetComponent<Button>().interactable = false;
            }
            else
            {
                WinLvlPnl.transform.GetChild(i - 1).GetComponent<Button>().interactable = true;
                LoseLvlPnl.transform.GetChild(i - 1).GetComponent<Button>().interactable = true;
                StartLvlPnl.transform.GetChild(i - 1).GetComponent<Button>().interactable = true;
            }
        }

    }
    public void LevelUp()
    {
        if (PlayerPrefs.GetInt("Level" + Convert.ToInt32(SceneManager.GetActiveScene().buildIndex + 2)) == 0)
        {
            Debug.Log("Level" + Convert.ToInt32(SceneManager.GetActiveScene().buildIndex + 2));
            PlayerPrefs.SetInt("Level" + Convert.ToInt32(SceneManager.GetActiveScene().buildIndex + 2), 1);

            return;
        }

    }
    public void QualitySlider()
    {
        if (QualitySlide.value > 0.6f)
        {
            QualitySettings.SetQualityLevel(2, true);
        }
        else if (QualitySlide.value <= 0.6f && QualitySlide.value >= 0.4f)
        {
            QualitySettings.SetQualityLevel(1, true);
        }
        else
        {
            QualitySettings.SetQualityLevel(1, true);
        }
    }
    public void MasterSlider()
    {
       PlayerPrefs.SetFloat("MusicVolume", AudioSlider.value);
        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void StartGameButton()
    {
        isStarted = true;
        StartMenuCanvas.SetActive(false);
    }
    public void PutValuesIntoSettings()
    {
        AudioSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        switch (QualitySettings.GetQualityLevel())
        {
            case 0: Debug.Log(QualitySettings.GetQualityLevel()); QualitySlide.value = 0f; break;
            case 1: Debug.Log(QualitySettings.GetQualityLevel()); QualitySlide.value = 0.5f; break;
            case 2: Debug.Log(QualitySettings.GetQualityLevel()); QualitySlide.value = 1f; break;
        }
    }
    public void InitialNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    IEnumerator DelayWin()
    {
        yield return new WaitForSeconds(1f);
        WinCanvas.SetActive(true);
        Time.timeScale = 1;
    }
    IEnumerator DelayLose()
    {
        yield return new WaitForSeconds(1f);
        LoseCanvas.SetActive(true);
        Time.timeScale = 1;
    }
}
