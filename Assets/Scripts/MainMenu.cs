using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject startGameBtn;
    [SerializeField] GameObject quitGameBtn;

    public void OnClickStartGameBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnClickQuitGameBtn()
    {
        Application.Quit();
    }
}
