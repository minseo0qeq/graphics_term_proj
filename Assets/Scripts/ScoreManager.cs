using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public static ScoreManager Instance { get; private set; }

    public delegate void UpdateScore(int newScore);
    public event UpdateScore OnScoreUpdate;

    // Start is called before the first frame update
    void Awake()
    {
        //Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        score = 0;
    }


    public void AddScore()
    {
        score++;
        OnScoreUpdate?.Invoke(score);
    }

}