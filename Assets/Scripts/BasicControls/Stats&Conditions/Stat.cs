using System;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField]
    private float baseValue;
    private float modifiedValue;
    private float flatIncrease;
    private float percentIncrease;//in form of decimals (0.01f for 1%)

    public void Init()
    {
        modifiedValue = baseValue;
    }

    public float FlatIncrease
    {
        get => flatIncrease;
        set
        {
            flatIncrease = value;
            ModifyValue();
        }
    }
    
    public float PercentIncrease
    {
        get => percentIncrease;
        set
        {
            percentIncrease = value;
            ModifyValue();
        }
    }

    private void ModifyValue()
    {
        modifiedValue = (1.0f + percentIncrease) * (flatIncrease + baseValue);
    }

    public float Value => modifiedValue;
}