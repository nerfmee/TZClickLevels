
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private ClickableItem clickableItem;

    private Vector2 _width;
    private Vector2 _height;
    private Vector2 _itemSize;

    private float _clickCountsToWin = 0;
    private int _bonusSpawnChance = 0;

    public static Action<float> OnStartLevel;
    public static Action<float, float, float> OnUpdateProgressBar;
    public static Action OnComleteLevel;
    
    
    private float _progressBarCounter = 0;
    public int ProgressStep { get; set; } = 1;

    private Bonus[] _bonusesInLevel = Array.Empty<Bonus>();
    private Bonus[] spawnedBonuses = Array.Empty<Bonus>();
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

    public void StartLevel( LevelSettings levelSettings)
    {
        _bonusesInLevel = levelSettings.Bonuses;
        _clickCountsToWin = levelSettings.ClickCountsToWin;
        _bonusSpawnChance = levelSettings.BonusSpawnChance;

        InitializeLevelBonuses();
        OnStartLevel?.Invoke(_clickCountsToWin);
        clickableItem.gameObject.SetActive(true);
    }

    private void InitializeLevelBonuses()
    {
        foreach (var bonus in _bonusesInLevel)
        {
            Bonus tempBonus = Instantiate(bonus);
            
            Array.Resize(ref spawnedBonuses, spawnedBonuses.Length+1);
            spawnedBonuses[spawnedBonuses.Length-1] = tempBonus;
            
            tempBonus.Initialize(this);
        }
    }

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
        OnUpdateProgressBar?.Invoke(progressBarStep, _progressBarCounter, _clickCountsToWin);
        
        if (_progressBarCounter >= _clickCountsToWin)
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        OnComleteLevel?.Invoke();
        clickableItem.gameObject.SetActive(false);
    }

    private void TeleportToRandomPlace()
    {
        clickableItem.transform.position = CalculateRandomPosition();
    }

    private void SpawnBonus()
    {
        int random = Random.Range(0, 101);
        
        if (random <= _bonusSpawnChance)
        {
            Bonus randomBonus = SelectRandomBonus();
            randomBonus.gameObject.SetActive(true);
        }
    }

    private Bonus SelectRandomBonus()
    {
        int randomElement = Random.Range(0, spawnedBonuses.Length);
        Bonus bonus = spawnedBonuses[randomElement];
        return bonus;
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
