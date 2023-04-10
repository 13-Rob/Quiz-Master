using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswer = 30f;
    [SerializeField] float timeToShowAnswer = 10f;
    public bool loadNext;
    public bool isAnswering = true;
    public float fillFraction;
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (timerValue > 0)
        {
            fillFraction = isAnswering ? timerValue / timeToAnswer : timerValue / timeToShowAnswer;
        }
        else
        {
            isAnswering = !isAnswering;

            if (isAnswering)
                timerValue = timeToAnswer;
            else
            {
                timerValue = timeToShowAnswer;
                loadNext = true;
            }
        }

        Debug.Log(fillFraction);
    }
}
