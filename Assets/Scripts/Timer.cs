using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeRemaining = 60f;
    [SerializeField] float timeRunningOut = 15f;
    [SerializeField] TextMeshProUGUI timeText;

    bool timerIsRunning = false;
    bool timeIsRunningOut = false;
    GameController gameController;
    AudioController audioController;

    private void Start()
    {
        gameController = FindAnyObjectByType<GameController>();
        audioController = FindAnyObjectByType<AudioController>();
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining <= timeRunningOut && !timeIsRunningOut)
            {
                timeIsRunningOut = true;
                audioController.SetMusicPitch(1.5f);
            }

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
                gameController.GameOver();
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
