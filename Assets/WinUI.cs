using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{

    [SerializeField] private GameObject winWindow;
    private void OnEnable()
    {
        GameBoard.OnWin += Activate;
    }

    private void OnDisable()
    {
        GameBoard.OnWin -= Activate;
    }

    private void Activate()
    {
        winWindow.SetActive(true);
    }
}
