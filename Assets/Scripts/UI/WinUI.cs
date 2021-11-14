using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{

    [SerializeField] private GameObject winWindow;
    private void OnEnable()
    {
        GameBoard.OnComleteLevel += Activate;
    }

    private void OnDisable()
    {
        GameBoard.OnComleteLevel -= Activate;
    }

    private void Activate()
    {
        winWindow.SetActive(true);
    }
}
