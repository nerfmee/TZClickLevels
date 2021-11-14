using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressBarImage;
    [SerializeField] private Text progressText;
    [SerializeField] private RectTransform progressBarContainer;
    
    public void OnEnable()
    {
        GameBoard.OnStartLevel += Initialize;
        GameBoard.OnUpdateProgressBar += UpdateProgressBar;
        GameBoard.OnCompleteLevel += Deactivate;
    }

    public void OnDisable()
    {
        GameBoard.OnStartLevel -= Initialize;
        GameBoard.OnUpdateProgressBar -= UpdateProgressBar;
        GameBoard.OnCompleteLevel -= Deactivate;
    }

    private void Initialize(float countsToWin)
    {
        UpdateProgressBar(0, 0, countsToWin);
        progressBarContainer.gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        progressBarContainer.gameObject.SetActive(false);
    }

    private void UpdateProgressBar(float fillAmountValue, float progressBarCounter, float fullProgress)
    {
        if (progressBarCounter >= fullProgress)
        {
            progressBarCounter = fullProgress;
        }
        
        progressBarImage.fillAmount = fillAmountValue;
        string currentValue = ((int) progressBarCounter).ToString();
        progressText.text = $"{currentValue}/{fullProgress}";
    }
    
    
}
