using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private RowUI rowUi;
    [SerializeField] private Transform levelScoresParent;
    [SerializeField] private ScoreManager scoreManager;

    public void SpawnScores(Level level)
    {
        RemovePreviousScores();
        if (level.ScoreData.scores.Count > 0)
        {
            Score[] scores = scoreManager.GetHighScores(level.ScoreData).ToArray();
            foreach (var score in scores)
            {
                RowUI row = Instantiate(rowUi, levelScoresParent);
                row.name.text = score.name;
                row.score.text = score.score.ToString();
            }
        }
    }

    private void RemovePreviousScores()
    {
        for (int i = 0; i < levelScoresParent.childCount; i++)
        {
            levelScoresParent.GetChild(i).gameObject.SetActive(false);
        }
    }
}

