public class GameMenu : MenuState
{
    public override void InitState(MenuController menu)
    {
        base.InitState(menu);

        State = MenuController.MenuType.Game;
    }

    public void JumpToLevels()
    {
        base.menuController.SetActiveState(MenuController.MenuType.Levels);
    }
}
