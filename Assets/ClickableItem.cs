using System;
using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer itemSpriteRenderer;
    public SpriteRenderer ItemSpriteRenderer => itemSpriteRenderer;
    private GameBoard _gameBoard;
    public GameBoard GameBoard
    {
        set => _gameBoard = value;
    }
    
    #region Input

    public void OnMouseDown()
    {
        SelectItem();
    }
    
    #endregion

    private void SelectItem()
    {
        _gameBoard.ProgressApply();
    }

}