using System;
using UnityEngine;

public class LifeSystem : Stats
{
    public event Action<float> onLifeChanged;
    public LifeSystem(float minValue, float maxValue, float currentValue) : base(minValue, maxValue, currentValue)
    {
    }
    public void Heal(float amount)
    {
        CurrentValue += amount;
        onLifeChanged?.Invoke(CurrentValue);
    }
    public void TakeDamage(float amount)
    {
        CurrentValue -= amount;
        onLifeChanged?.Invoke(CurrentValue);
    }
}

