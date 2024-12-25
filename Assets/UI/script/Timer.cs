using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float time;
    private int min;
    private int sec;
    private bool isTimeOver;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "01 : 00";
        time = 90;
        isTimeOver = false;
    }

    // Update is called once per frame
    void Update()
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
                if (ScoreManager.Instance.score < 10)
                {
                    SceneManager.LoadScene("End1");
                }else if(ScoreManager.Instance.score <= 20)
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
