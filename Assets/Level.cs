using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New_Level")]
public class Level : ScriptableObject
{
   [Range(0,100)] [SerializeField] private int tapCountsForWin;
   
   [SerializeField] private BonusesSettings.BonusesSetup[] bonuses;

    public BonusesSettings.BonusesSetup[] Bonuses => bonuses;
   
   
}
