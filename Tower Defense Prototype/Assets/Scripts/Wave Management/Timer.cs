using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float startingTime = 20;
    private float timeLeft = 20;

    private bool TimerOn = false;

    [SerializeField]
    private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = startingTime;
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                timeLeft = 0;
                TimerOn = false;
            }
        }
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        TimerOn = true;
    }

    public void ResetTimer()
    {
        timeLeft = startingTime;

        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
