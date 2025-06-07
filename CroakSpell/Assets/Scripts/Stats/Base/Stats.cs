using UnityEngine;

public abstract class Stats
{
    private float maxValue;
    private float minValue;
    private float currentValue;

  
    public delegate void OnStatChangedDelegate(float newValue, float maxValue);

    
    public event OnStatChangedDelegate OnValueChanged;

  
    protected Stats(float minValue, float maxValue, float currentValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        OnValueChanged?.Invoke(this.currentValue, this.maxValue);
    }


    public float MaxValue
    {
        get { return maxValue; }
        protected set { maxValue = value; }
    }

    
    public float CurrentValue => currentValue;

    public virtual void ModifyValue(float amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, minValue, maxValue);
        OnValueChanged?.Invoke(currentValue, maxValue);
    }
}
