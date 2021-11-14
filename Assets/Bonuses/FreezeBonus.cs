using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBonus : Bonus
{
    private GameBoard _gameBoard;
    public override void Initialize(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
    }

    protected override void OnMouseDown()
    {
        ActivateBonus();
    }

    protected override void ActivateBonus()
    {
        _gameBoard.IsExistBonusInLevel = false;
        
        _gameBoard.IsFreeze = true;
        gameObject.SetActive(false);
    }
}
