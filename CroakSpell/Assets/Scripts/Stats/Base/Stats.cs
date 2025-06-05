using UnityEngine;

public abstract class Stats
{
    private float maxValue;
    private float minValue;
    private float currentValue;

    /// <summary>
    /// Delegado para notificar cuando el valor de la estadística cambia.
    /// </summary>
    /// <param name="newValue">Nuevo valor actual de la estadística.</param>
    /// <param name="maxValue">Valor máximo de la estadística.</param>
    public delegate void OnStatChangedDelegate(float newValue, float maxValue);

    /// <summary>
    /// Evento que se dispara cuando el valor de la estadística cambia.
    /// </summary>
    public event OnStatChangedDelegate OnValueChanged;

    /// <summary>
    /// Constructor protegido para inicializar los valores de la estadística.
    /// </summary>
    /// <param name="minValue">Valor mínimo permitido.</param>
    /// <param name="maxValue">Valor máximo permitido.</param>
    /// <param name="currentValue">Valor inicial de la estadística.</param>
    protected Stats(float minValue, float maxValue, float currentValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        OnValueChanged?.Invoke(this.currentValue, this.maxValue);
    }

    /// <summary>
    /// Propiedad para obtener o establecer el valor máximo de la estadística.
    /// Solo accesible desde clases derivadas.
    /// </summary>
    public float MaxValue
    {
        get { return maxValue; }
        protected set { maxValue = value; }
    }

    /// <summary>
    /// Propiedad de solo lectura para obtener el valor actual de la estadística.
    /// </summary>
    public float CurrentValue => currentValue;

    /// <summary>
    /// Modifica el valor actual de la estadística, asegurando que permanezca entre el mínimo y el máximo.
    /// Dispara el evento OnValueChanged si hay cambios.
    /// </summary>
    /// <param name="amount">Cantidad a modificar (puede ser positiva o negativa).</param>
    public virtual void ModifyValue(float amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, minValue, maxValue);
        OnValueChanged?.Invoke(currentValue, maxValue);
    }
}
