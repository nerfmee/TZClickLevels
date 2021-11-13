using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _progressBarImage;
    
    public void OnEnable()
    {
        GameBoard.OnUpdateProgressBar += UpdateProgressBar;
    }

    public void OnDisable()
    {
        GameBoard.OnUpdateProgressBar -= UpdateProgressBar;
    }

    private void UpdateProgressBar(float fillAmountValue)
    {
        _progressBarImage.fillAmount = fillAmountValue;
    }
}
