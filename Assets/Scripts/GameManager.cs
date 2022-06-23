using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singlton<GameManager>
{
    public Action <bool> OnWoodCountChanged;
    private int woodCount;

    public int Wood { 
        get => woodCount;  
        set 
        {
            OnWoodCountChanged?.Invoke(value - woodCount > 0);
            woodCount = value;
        } 
    }

    private void Start()
    {
        Wood = 0;
    }
}
