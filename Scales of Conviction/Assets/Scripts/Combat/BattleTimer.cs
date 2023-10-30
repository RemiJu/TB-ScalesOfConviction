using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTimer : MonoBehaviour
{
    public enum whoseTurn
    {
        Player,
        Opponent
    }

    public TurnManager turnManager;
    public whoseTurn turn;
    public Slider timerSlider; // Reference to the UI Slider
    public float maxTime = 60f; // Maximum time in seconds
    public float speedMultiplier = 1f; // Speed at which the timer fills
    private float currentTime = 0f;
    public bool isRunning = false;

    private void Awake()
    {
        switch (turn)
        {
            case whoseTurn.Player:
                speedMultiplier = StatManager.Instance.playerSpdMult;
                break;
            case whoseTurn.Opponent:
                speedMultiplier = StatManager.Instance.enemySpdMult;
                break;
        }
        StartTimer();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime * speedMultiplier;
            if (currentTime >= maxTime)
            {

                currentTime = maxTime;
                isRunning = false;
                switch (turn)
                {
                    case whoseTurn.Player:
                        NotifyPlayerSliderFull();
                        break;
                    case whoseTurn.Opponent:
                        NotifyEnemySliderFull();
                        break;
                }
            }
            UpdateSlider();
        }
    }

    private void UpdateSlider()
    {
        timerSlider.value = currentTime / maxTime;
    }

    //Timer Control

    public void StartTimer()
    {
        isRunning = true;
        Debug.Log("Timer has started.");
    }

    public void StopTimer()
    {
        isRunning = false;
        Debug.Log("Timer has stopped.");
    }

    public void ResetTimer()
    {
        currentTime = 0f;
        UpdateSlider();
    }

    private void NotifyPlayerSliderFull()
    {
        turnManager.PlayerTimerFull();

    }

    private void NotifyEnemySliderFull()
    {
        turnManager.EnemyTimerFull();
    }
}
