using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public static ScoreManager Instance {get; private set;}

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(){
        score++;
        OnScoreUpdate?.Invoke(score);
    }
}
