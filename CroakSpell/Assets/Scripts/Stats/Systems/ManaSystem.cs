using System;
using UnityEngine;

public class ManaSystem : Stats
{
    public float SpeedRecharge { get; set; }
    public ManaSystem(float minValue, float maxValue, float currentValue, float speedRecharge) : base(minValue, maxValue, currentValue)
    {
        SpeedRecharge = speedRecharge;
    }

    public float CurrentMana => CurrentValue;

    public void Recharge(float amount)
    {
        ModifyValue(amount);
    }

    public void SpendMana(int amount)
    {
        ModifyValue(-amount);
    }
}
