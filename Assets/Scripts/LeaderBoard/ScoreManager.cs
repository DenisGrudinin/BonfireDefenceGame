using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    ScoreData scoreData;
    
    void Start()
    {
        scoreData = new ScoreData();
        var json = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString("scores", json);   
    }

    public IEnumerable<Score> GetHighScores()
    {
         return scoreData.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        scoreData.scores.Add(score);
    }

    public void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString("scores", json);
    }
}
