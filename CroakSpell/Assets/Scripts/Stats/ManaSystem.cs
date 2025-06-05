using System;
using UnityEngine;

public class ManaSystem : Stats
{
    public event Action<float> onManaChanged;

    public ManaSystem(float minValue, float maxValue, float currentValue) : base(minValue, maxValue, currentValue)
    {
    }

    public void RestoreMana(float amount)
    {
        CurrentValue += amount;
        onManaChanged?.Invoke(CurrentValue);
    }

    public void UseMana(float amount)
    {
        CurrentValue -= amount;
        onManaChanged?.Invoke(CurrentValue);
    }


}
