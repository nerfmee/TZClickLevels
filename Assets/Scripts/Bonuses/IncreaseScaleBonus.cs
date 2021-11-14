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
        int multiplier = 2;
        _gameBoard.IsExistBonusInLevel = false;
        _gameBoard.Clickable.transform.localScale *= multiplier;
        _gameBoard.ItemSize *= multiplier;
        gameObject.SetActive(false);
    }
}
