using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
   [SerializeField] GameObject playAgainBtn;
   [SerializeField] GameObject mainMenuBtn;

    public void OnClickPlayAgainBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickMainMenuBtn()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
