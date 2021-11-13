
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private ClickableItem clickableItem;
    private Vector2 _width;
    private Vector2 _height;
    private Vector2 _itemSize;

    private float _clickCountsToWin = 20;
    private int _bonusSpawnChance = 50;

    [SerializeField] private DoubleTap _doubleTap;

    public static Action<float> OnUpdateProgressBar;
    public static Action OnWin;
    private void Awake()
    {
        Camera cameraMain = Camera.main;

        Vector2 min = cameraMain.ViewportToWorldPoint (new Vector2 (0,0)); // bottom-left corner
        Vector2 max = cameraMain.ViewportToWorldPoint (new Vector2 (1,1)); // top-right corner
        
        _width = new Vector2(min.x, max.x);
        _height = new Vector2(min.y, max.y);

        clickableItem.GameBoard = this;
        _itemSize = clickableItem.ItemSpriteRenderer.size;
    }

    private float _progressBarCounter = 0;
    public int ProgressStep { get; set; } = 1;

    public void ProgressApply()
    {
        SpawnBonus();
        UpdateProgressBar();
        TeleportToRandomPlace();
    }

    private void UpdateProgressBar()
    {
        _progressBarCounter += ProgressStep;
        float progressBarStep = _progressBarCounter / _clickCountsToWin;
        OnUpdateProgressBar?.Invoke(progressBarStep);
        
        if (_progressBarCounter >= _clickCountsToWin)
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        OnWin?.Invoke();
        clickableItem.gameObject.SetActive(false);
        
    }

    private void TeleportToRandomPlace()
    {
        clickableItem.transform.position = CalculateRandomPosition();
    }

    private void SpawnBonus()
    {
        _doubleTap.Initialize(this);
        _doubleTap.gameObject.SetActive(true);
    }


    private Vector2 CalculateRandomPosition()
    {
        Vector2 randomPosition = new Vector2(Random.Range(_width.x, _width.y), Random.Range(_height.x, _height.y));

        Vector2 itemSizeX = new Vector2(_itemSize.x * 0.5f, 0);
        Vector2 itemSizeY = new Vector2(0, _itemSize.y * 0.5f);
        
        randomPosition += randomPosition.x < 0 ? itemSizeX : -itemSizeX;
        randomPosition += randomPosition.y < 0 ? itemSizeY : -itemSizeY;
        
        return randomPosition;
    }
}
