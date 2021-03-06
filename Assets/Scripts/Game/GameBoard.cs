using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameBoard : MonoBehaviour
{
    public static Action<GameBoard> OnStartTimer;
    public static Action<float> OnStartLevel;
    public static Action<float, float, float> OnUpdateProgress;
    public static Action OnCompleteLevel;
    public static Action<Level, Score> OnSaveScoreResult;
    
    [SerializeField] private ClickableItem clickableItem;
    [SerializeField] private Transform bonusesParent;
    public ClickableItem Clickable => clickableItem;

    private Bonus[] _bonusesInLevel = Array.Empty<Bonus>();
    private Bonus[] spawnedBonuses = Array.Empty<Bonus>();

    public Vector2 ItemSize { get => _itemSize; set => _itemSize = value; }

    private Vector2 _width;
    private Vector2 _height;
    private Vector2 _itemSize;

    private float _clickCountsToWin = 0;
    private int _bonusSpawnChance = 0;
    
    private float _progressBarCounter = 0;
    public int ProgressStep { get; set; } = 1;
    private bool isFreeze = false;

    public bool IsFreeze { set => isFreeze = value; }

    private bool isExistBonusInLevel = false;

    public bool IsExistBonusInLevel { set => isExistBonusInLevel = value; }

    private int points;
    public int Points { set => points = value; }

    private Level currentLevel;

    private void Awake()
    {
        Camera cameraMain = Camera.main;

        Vector2 min = cameraMain.ViewportToWorldPoint(new Vector2(0, 0)); // bottom-left corner
        Vector2 max = cameraMain.ViewportToWorldPoint(new Vector2(1, 1)); // top-right corner

        _width = new Vector2(min.x, max.x);
        _height = new Vector2(min.y, max.y);

        clickableItem.GameBoard = this;
        _itemSize = clickableItem.ItemSpriteRenderer.size;
    }
    
    #region Progress
    public void ProgressApply()
    {
        SpawnBonus();
        UpdateProgress();
        TeleportToRandomPlace();
    }

    private void UpdateProgress()
    {
        _progressBarCounter += ProgressStep;
        float progressBarStep = _progressBarCounter / _clickCountsToWin;
        OnUpdateProgress?.Invoke(progressBarStep, _progressBarCounter, _clickCountsToWin);

        if (_progressBarCounter >= _clickCountsToWin)
        {
            CompleteLevel(currentLevel);
        }
    }
    #endregion

    #region Bonuses
    private void InitializeLevelBonuses()
    {
        foreach (var bonus in _bonusesInLevel)
        {
            //TO DO: object pool 
            Bonus tempBonus = Instantiate(bonus, bonusesParent);

            Array.Resize(ref spawnedBonuses, spawnedBonuses.Length + 1);
            spawnedBonuses[spawnedBonuses.Length - 1] = tempBonus;

            tempBonus.Initialize(this);
            tempBonus.gameObject.SetActive(false);
        }
    }
    private void SpawnBonus()
    {
        if (isExistBonusInLevel == false)
        {
            int random = Random.Range(0, 101);

            if (random <= _bonusSpawnChance)
            {
                isExistBonusInLevel = true;
                Bonus randomBonus = SelectRandomBonus();
                randomBonus.gameObject.SetActive(true);
            }
        }
    }

    private Bonus SelectRandomBonus()
    {
        int randomElement = Random.Range(0, spawnedBonuses.Length);
        Bonus bonus = spawnedBonuses[randomElement];
        return bonus;
    }
    #endregion

    #region Positions
    private void TeleportToRandomPlace()
    {
        if (isFreeze == false)
        {
            clickableItem.transform.position = CalculateRandomPosition();
        }
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
    
    #endregion

    #region Level
    public void StartLevel(Level level)
    {
        currentLevel = level;
        LevelSettings levelSettings = level.LevelSettings;
        _bonusesInLevel = levelSettings.Bonuses;
        _clickCountsToWin = levelSettings.ClickCountsToWin;
        _bonusSpawnChance = levelSettings.BonusSpawnChance;

        InitializeLevelBonuses();
        OnStartLevel?.Invoke(_clickCountsToWin);
        OnStartTimer?.Invoke(this);
        clickableItem.gameObject.SetActive(true);
    }
    private void CompleteLevel(Level level)
    {
        OnCompleteLevel?.Invoke();
        OnSaveScoreResult?.Invoke(level, new Score("Player", points));
        ResetSpawnValues();
    }

    #endregion
    
    private void ResetSpawnValues()
    {
        clickableItem.gameObject.transform.localScale = Vector3.one;
        _itemSize = clickableItem.ItemSpriteRenderer.size;
        isFreeze = false;
        isExistBonusInLevel = false;
        _progressBarCounter = 0;
        ProgressStep = 1;

        clickableItem.gameObject.SetActive(false);
        foreach (var spawnedBonus in spawnedBonuses)
        {
            spawnedBonus.gameObject.SetActive(false);
        }

        spawnedBonuses = Array.Empty<Bonus>();
    }
}
