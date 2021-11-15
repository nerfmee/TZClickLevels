using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{

    [SerializeField] private GameObject timerParent;
    [SerializeField] private Text timeText;
    private float currentTime;

    private int _maxPointsCount = 500;
    private float allSeconds = 0;

    private GameBoard _gameBoard;
    
    private void OnEnable()
    {
        GameBoard.OnCompleteLevel += DeactivateTimer;
        GameBoard.OnStartTimer += ActivateTimer;
    }
    
    private void OnDisable()
    {
        GameBoard.OnCompleteLevel -= DeactivateTimer;
        GameBoard.OnStartTimer -= ActivateTimer;
        ResetValues();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        DisplayTime(currentTime);
    }

    private void ActivateTimer(GameBoard gameBoard)
    {
        timerParent.SetActive(true);
        _gameBoard = gameBoard;
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        allSeconds = timeToDisplay;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = $"{minutes:00}:{seconds:00}";
    }
    
    private void DeactivateTimer()
    {
        int points = (int) (-1 * allSeconds + _maxPointsCount);
        _gameBoard.Points = points;
        timerParent.SetActive(false);
    }

    private void ResetValues()
    {
        allSeconds = 0;
        currentTime = 0;
    }
}
