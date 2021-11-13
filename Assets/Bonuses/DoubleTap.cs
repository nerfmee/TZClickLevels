using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoubleTap : Bonus
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
    
    protected override void ActivateBonus( )
    {
        _gameBoard.ProgressStep += 1;
        gameObject.SetActive(false);
    }
    
}
