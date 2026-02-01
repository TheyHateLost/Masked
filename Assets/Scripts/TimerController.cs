using UnityEngine;
using TMPro; // Add this if using TextMeshPro
using UnityEngine.SceneManagement; // Useful if you want to restart on 0

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 60f; // Start time in seconds
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText; // Drag your UI text here

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver(); // Trigger whatever happens at 0
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Formats the time into Minutes and Seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Updates the text string
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        // Add logic here (e.g., stop the road moving, show a menu)
    }
    public void AddTime(float amount)
    {
        timeRemaining += amount;
        // Optional: Flash the text green to show time was added
        timeText.color = Color.green;
        Invoke("ResetColor", 0.5f);
    }
}

