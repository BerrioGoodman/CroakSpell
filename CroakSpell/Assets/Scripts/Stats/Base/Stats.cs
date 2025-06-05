using UnityEngine;

public abstract class Stats
{
    private float maxValue;
    private float minValue;
    private float currentValue;

    protected Stats(float minValue, float maxValue, float currentValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.currentValue = currentValue;
    }

    public float MaxValue
    {
        get { return maxValue; }
        protected set { maxValue = value; }
    }

    public float MinValue
    {
        get { return minValue; }
        protected set { minValue = value; }
    }

    public float CurrentValue
    {
        get { return currentValue; }
        protected set { currentValue = Mathf.Clamp(value, minValue, maxValue); }
    }

}
