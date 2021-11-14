using System;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelSettings levelSettings;
    [SerializeField] private Text levelNameText;

    public GameBoard GameBoard { get; set; }
    private LevelsHandler _levelsHandler;
    
    public void InitializeLevelPanel()
    {
        levelNameText.text = levelSettings.LevelName;
    }

    public void StartLevel()
    {
        GameBoard.StartLevel(levelSettings);
    }
}