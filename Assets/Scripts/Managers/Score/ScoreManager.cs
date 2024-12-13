using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private Score score;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        score = FindAnyObjectByType<Score>();
    }
    public void AddScore(int s)
    {
        score.AddScore(s);
    }
    public void RemoveScore(int s)
    {
        score.RemoveScore(s);
    }
}
