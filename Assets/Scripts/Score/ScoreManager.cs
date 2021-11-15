using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameBoard.OnSaveScoreResult += AddScore;
    }

    private void OnDisable()
    {
        GameBoard.OnSaveScoreResult -= AddScore;
    }
    
    public void LoadScoreData(Level level)
    {
        string levelKey = level.LevelSettings.LevelName;
        var json = PlayerPrefs.GetString(levelKey, "{}");
        
        level.ScoreData = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores(ScoreData scoreData)
    {
        return scoreData.scores.OrderByDescending(x => x.score);
    }

    private void AddScore(Level level, Score score)
    {
        ScoreData scoreData = level.ScoreData;
        scoreData.scores.Add(score);
        SaveScore(scoreData, level.LevelSettings.LevelName);
    }
    
    private void SaveScore(ScoreData scoreData, string levelKey)
    {
        var json = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString(levelKey, json);
    }
}


















