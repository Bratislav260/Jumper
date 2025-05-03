using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool isRunning = false;

    public void TimerUpdate()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            DisplayTime(elapsedTime);
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        DisplayTime(elapsedTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
