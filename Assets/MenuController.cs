using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public MenuState[] allMenus;

    public enum MenuType
    {
        Game, 
        Main, 
        Settings,
        Help,
        Levels,
        LevelInfo
    }

  
    private Dictionary<MenuType, MenuState> menuDictionary = new Dictionary<MenuType, MenuState>();
    
    private MenuState activeState;
    
    private Stack<MenuType> stateHistory = new Stack<MenuType>();

    private void Start()
    {
        foreach (MenuState menu in allMenus)
        {
            if (menu == null)
            {
                continue;
            }

            //Inject a reference to this script into all menus
            menu.InitState(menu: this);

            //Check if this key already exists, because it means we have forgotten to give a menu its unique key
            if (menuDictionary.ContainsKey(menu.State))
            {
                Debug.LogWarning($"The key <b>{menu.State}</b> already exists in the menu dictionary!");

                continue;
            }
            
            menuDictionary.Add(menu.State, menu);
        }

        //Deactivate all menus
        foreach (MenuType menuType in menuDictionary.Keys)
        {
            menuDictionary[menuType].gameObject.SetActive(false);
        }

        //Activate the default menu
        SetActiveState(MenuType.Levels);
    }

    public void JumpBack()
    {
        if (stateHistory.Count <= 1)
        {
            SetActiveState(MenuType.Main);
        }
        else
        {
          
            stateHistory.Pop();

           
            SetActiveState(stateHistory.Peek(), isJumpingBack: true);
        }
    }

    public void SetActiveState(MenuType newType, bool isJumpingBack = false)
    {
      
        if (!menuDictionary.ContainsKey(newType))
        {
            Debug.LogWarning($"The key <b>{newType}</b> doesn't exist so you can't activate the menu!");

            return;
        }

       
        if (activeState != null)
        {
            activeState.gameObject.SetActive(false);
        }

       
        activeState = menuDictionary[newType];

        activeState.gameObject.SetActive(true);

        
        if (!isJumpingBack)
        {
            stateHistory.Push(newType);
        }
    }
}
