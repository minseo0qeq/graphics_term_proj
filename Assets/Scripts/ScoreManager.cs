using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text timerText;
    private float time;
    private int min;
    private int sec;
    private bool isTimeOver;
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
        time = 30;
        isTimeOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public void AddScore()
    {
        score++;
        OnScoreUpdate?.Invoke(score);
    }

    void Timer()
    {
        time -= Time.deltaTime;

        min = (int)time / 60;
        sec = ((int)time - min * 60) % 60;

        if (min <= 0 && sec <= 0)
        {
            if (isTimeOver == false)
            {
                isTimeOver = true;
                timerText.text = 0.ToString() + " : " + 0.ToString();
                Debug.Log("time out");
                if (score < 10)
                {
                    SceneManager.LoadScene("End1");
                }else if (score >= 10 && score <= 20)
                {
                    SceneManager.LoadScene("End2");
                }
                else
                {
                    SceneManager.LoadScene("End3");
                }
            }

        }
        else
        {
            if (sec >= 60)
            {
                min += 1;
                sec -= 60;
            }
            else
            {
                timerText.text = min.ToString() + " : " + sec.ToString();

            }
        }
    }

}