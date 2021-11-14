using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScaleBonus : Bonus
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
        int multiplier = 2;
        _gameBoard.Clickable.transform.localScale *= multiplier;
        _gameBoard.ItemSize *= multiplier;
        gameObject.SetActive(false);
    }
}
