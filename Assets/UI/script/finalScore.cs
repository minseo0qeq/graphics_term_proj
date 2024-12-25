using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class finalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            finalScoreText.text = "score : " + ScoreManager.Instance.score;
        }
        else
        {
            finalScoreText.text = "score : 0";
        }
    }
    void Update()
    {
        
    }
}
