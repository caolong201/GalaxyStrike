using System;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int Score = 0;
    [SerializeField] TextMeshProUGUI textScore;

  
    public void InScorePlayer ( int dameg)
    {
        Score += dameg;
        textScore.text = Score.ToString();
        Debug.Log(Score);
    }
}
