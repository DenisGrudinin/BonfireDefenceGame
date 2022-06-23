using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using System.Linq;
using System.Collections;

public class BonfireHealthBar : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] TextMeshProUGUI woodText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] float fill;
    public static bool lose;

    void Start()
    {
        lose = false;
        fill = 1f;
        woodText.DOColor(Color.yellow, 0);
        GameManager.GetInstance().OnWoodCountChanged += UpdateWoodCount;
        StartCoroutine(MinusHealth());
    }
    private void Update()
    {
        UpdateHealthBar();
        UpdateWoodCount(true);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (lose == false)
        {
            if (other.gameObject.tag == "Enemy")
            {
                fill -= Random.Range(0.09f, 0.21f);
            }
            if (GameManager.GetInstance().Wood > 0 && fill < 1)
            {
                if (other.gameObject.tag == "Player")
                {
                    fill += Random.Range(0.09f, 0.21f);
                    //woodCount -= 1;
                    GameManager.GetInstance().Wood -= 1;

                }
            }
        }

        if (fill <= 0f)
        {
            lose = true; 
            SceneManager.LoadScene("EndGameScene");
        }

        if (fill > 1f)
        {
            fill = 1f;
        }
        //UpdateHealthBar();
    }

    void UpdateWoodCount(bool status)
    {
        woodText.text = "Wood: " + GameManager.GetInstance().Wood;
    }

    void UpdateHealthBar()
    {
        bar.fillAmount = fill;
        healthText.text = "Health: " + System.Math.Floor(fill * 100);

        if (System.Math.Floor(fill * 100) <= 35)
        {
            healthText.DOColor(Color.red, 5);
        }
        else if (System.Math.Floor(fill * 100) >= 50)
        {
            healthText.DOColor(Color.green, 5);
        }
        else
        {
            healthText.DOColor(Color.yellow, 5);
        }
    }

    IEnumerator MinusHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            fill -= 0.01f;
        }
    }
}
