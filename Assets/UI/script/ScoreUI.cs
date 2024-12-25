using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        ScoreManager.Instance.OnScoreUpdate += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreUpdate -= UpdateScoreText;
    }

    private void UpdateScoreText(int newScore)
    {
        scoreText.text = "x" + newScore;
    }
}