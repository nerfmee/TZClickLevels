using System;
using System.Collections.Generic;
using UnityEngine;

public class BonusesSettings : MonoBehaviour
{
    public enum BonusType
    {
        Default,
        DoubleTap,
        IncreaseScale,
        Freeze,
    }


    [Serializable]  public struct BonusesSetup
    {
        public BonusType BonusType;
        public GameObject BonusVisual;
    }

  
    
    
    private Dictionary<BonusType , Bonus> _mechanicsRouter;

    private void SetMechanics()
    {
        _mechanicsRouter = new Dictionary<BonusType, Bonus>
        {
           // {BonusType.DoubleTap, new DoubleTap()},
            
        };
    }


}
