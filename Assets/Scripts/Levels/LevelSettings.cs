using UnityEngine;

[CreateAssetMenu(menuName = "New_Level")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private string levelName;
    public string LevelName => levelName;
    [SerializeField] private int clickCountsToWin;
    public int ClickCountsToWin => clickCountsToWin;
    [Range(0, 100)] [SerializeField] private int bonusSpawnChance;
    public int BonusSpawnChance => bonusSpawnChance;
    [SerializeField] private Bonus[] bonuses;
    public Bonus[] Bonuses => bonuses;
}