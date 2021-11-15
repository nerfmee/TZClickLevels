using UnityEngine;

public class LevelsHandler : MonoBehaviour
{
   [SerializeField] private GameBoard gameBoard;
   [SerializeField] private ScoreManager scoreManager;
   
   public ScoreManager ScoreManager => scoreManager;
   public Level CurrentLevel { get; set; }

   [SerializeField] private Level[] levels;
   public Level[] Levels => levels;
  

   private void Start()
   {
      InitializeLevels();
   }

   private void InitializeLevels()
   {
      foreach (var level in levels)
      {
         level.GameBoard = gameBoard;
         level.InitializeLevelPanel();
         InitializeLevelScoreData(level);
      }
   }

   private void InitializeLevelScoreData(Level level)
   {
      scoreManager.LoadScoreData(level);
   }
}
