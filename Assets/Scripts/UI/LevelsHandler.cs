using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsHandler : MonoBehaviour
{
   [SerializeField] private GameBoard gameBoard;
   public Level CurrentLevel { get; set; }

   [SerializeField] private Level[] levels;
  

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
      }
   }
}
