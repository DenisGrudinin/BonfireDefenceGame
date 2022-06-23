using System;
using UnityEngine;

[Serializable]
public class Score : MonoBehaviour
{
    public float score;
    public string name;

    public Score(float score, string name)
    {
        this.score = score;
        this.name = name;
    }
}
