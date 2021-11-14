using UnityEngine;

public class WinUI : MonoBehaviour
{
    [SerializeField] private GameObject winWindow;
    private void OnEnable()
    {
        GameBoard.OnCompleteLevel += Activate;
    }

    private void OnDisable()
    {
        GameBoard.OnCompleteLevel -= Activate;
    }
    
    private void Activate()
    {
        winWindow.SetActive(true);
    }
    
    public void Deactivate()
    {
        winWindow.SetActive(false);
    }
}
