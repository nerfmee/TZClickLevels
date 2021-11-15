using System;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public LevelSettings LevelSettings => levelSettings;

    [SerializeField] private LevelSettings levelSettings;
    [SerializeField] private Text levelNameText;
    private ScoreData _scoreData = new ScoreData();
    public ScoreData ScoreData
    {
        get => _scoreData;
        set => _scoreData = value;
    }

    public GameBoard GameBoard { get; set; }
    private LevelsHandler _levelsHandler;
    
    public void InitializeLevelPanel()
    {
        levelNameText.text = levelSettings.LevelName;
    }

    public void StartLevel()
    {
        GameBoard.StartLevel(level:this);
    }
}