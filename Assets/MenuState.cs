using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : MonoBehaviour
{
    
    public MenuController.MenuType State { get; protected set; }


    protected MenuController menuController;

    public virtual void InitState(MenuController menu)
    {
        menuController = menu;
    }
    
    public void JumpBack()
    {
        menuController.JumpBack();
    }
}
