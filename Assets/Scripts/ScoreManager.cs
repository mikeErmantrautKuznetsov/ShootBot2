using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    public static int score;
    private int bestScore;

    private void Start()
    {
        score = 0;
    }

    private void FixedUpdate()
    {
        bestScore = (int)score;
        scoreText.text = " —чет: " + bestScore.ToString();

        if(PlayerPrefs.GetInt("Score (1)") <= bestScore)
        {
            PlayerPrefs.SetInt("Score (1)", bestScore);
        }

        bestScoreText.text = " Ћучший счет: " + PlayerPrefs.GetInt("Score (1)").ToString();
    }
}
