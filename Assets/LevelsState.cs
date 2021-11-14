using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsState : MenuState
{
    public override void InitState(MenuController menu)
    {
        base.InitState(menu);
        
        State = MenuController.MenuType.Levels;
    }
}
