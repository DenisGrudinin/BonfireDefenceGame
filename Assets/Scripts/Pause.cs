using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseBtn;
    [SerializeField] GameObject resumeBtn;
    [SerializeField] GameObject mainMenuBtn;
    [SerializeField] GameObject placeBtn;

    void Start()
    {
        pauseBtn.SetActive(true);
        resumeBtn.SetActive(false);
        mainMenuBtn.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickPauseButton()
    {
        pauseBtn.SetActive(false);
        resumeBtn.SetActive(true);
        mainMenuBtn.SetActive(true);
        placeBtn.SetActive(false);
        Time.timeScale = 0;
    }
    public void OnClickResumeButton()
    {
        pauseBtn.SetActive(true);
        resumeBtn.SetActive(false);
        mainMenuBtn.SetActive(false);
        placeBtn.SetActive(true);
        Time.timeScale = 1;
    }
    public void OnClickMainMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
