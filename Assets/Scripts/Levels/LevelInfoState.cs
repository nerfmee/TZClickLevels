using System;
using UnityEngine;

public class LevelInfoState : MenuState
{
    [SerializeField] private LevelsHandler levelsHandler;
    [SerializeField] private GameObject levelInfoWindow;
    [SerializeField] private GameObject levelsContainer;
    
    public override void InitState(MenuController menu)
    {
        base.InitState(menu);

        State = MenuController.MenuType.LevelInfo;
    }
    
    public void ActivateWindow(Level level)
    {
        base.menuController.SetActiveState(MenuController.MenuType.LevelInfo);
        levelsHandler.CurrentLevel = level;
    }

    public void DeactivateWindow()
    {
        levelInfoWindow.SetActive(false);
        levelsContainer.SetActive(true);
    }

    public void StartLevel()
    {
        base.menuController.SetActiveState(MenuController.MenuType.Game);
        levelsHandler.CurrentLevel.StartLevel();
    }


}
