using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class ParamData
{
    public Param Param;
    public int Value;
    public Vector2Int MinMax;
    public UnityEvent<int> OnValueChange;

    public void SetValue(int value)
    {
        Value = Mathf.Clamp(value, MinMax.x, MinMax.y);
    }
}

public enum Param
{
    Gold,
    Health
}