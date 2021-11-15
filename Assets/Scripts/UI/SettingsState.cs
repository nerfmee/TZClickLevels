public class SettingsState : MenuState
{
    public override void InitState(MenuController menu)
    {
        base.InitState(menu);

        State = MenuController.MenuType.Settings;
    }

  
}
