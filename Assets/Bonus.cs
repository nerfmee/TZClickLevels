﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    public abstract void Initialize(GameBoard gameBoard);

    protected abstract void OnMouseDown();
    protected abstract void ActivateBonus();
}
