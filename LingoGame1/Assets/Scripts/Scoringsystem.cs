using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoringsystem : MonoBehaviour
{

    public float Score;
    float TotalScore;
    float Percentage;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        TotalScore = 8;
        Percentage = 0;
    }
    public void CalculateScore()
    {
        Percentage = (Score/TotalScore) * 100;
        Debug.Log(Percentage);
    }
}
