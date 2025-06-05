using System;
using UnityEngine;

public class LifeSystem : Stats
{
    public LifeSystem(float minValue, float maxValue, float currentValue) : base(minValue, maxValue, currentValue)
    {
    }

    public void TakeDamage(float amount)
    {
        ModifyValue(-amount);
    }

    public void Heal(float amount)
    {
        ModifyValue(amount);
    }
}

