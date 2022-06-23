using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreManager scoreManager;

    void Start()
    {
        scoreManager.AddScore(new Score(WaveManager.currentLvl, "Den"));
        //scoreManager.AddScore(new Score(22, "Vasyl"));
        //scoreManager.AddScore(new Score(45, "Vasyl"));

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.score.text = scores[i].score.ToString();
            row.name.text = scores[i].name;
        }
    }
}
