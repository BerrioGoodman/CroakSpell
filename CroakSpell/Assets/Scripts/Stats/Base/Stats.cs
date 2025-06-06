using UnityEngine;

public abstract class Stats
{
    private float maxValue;
    private float minValue;
    private float currentValue;

    /// <summary>
    /// Delegado para notificar cuando el valor de la estad�stica cambia.
    /// </summary>
    /// <param name="newValue">Nuevo valor actual de la estad�stica.</param>
    /// <param name="maxValue">Valor m�ximo de la estad�stica.</param>
    public delegate void OnStatChangedDelegate(float newValue, float maxValue);

    /// <summary>
    /// Evento que se dispara cuando el valor de la estad�stica cambia.
    /// </summary>
    public event OnStatChangedDelegate OnValueChanged;

    /// <summary>
    /// Constructor protegido para inicializar los valores de la estad�stica.
    /// </summary>
    /// <param name="minValue">Valor m�nimo permitido.</param>
    /// <param name="maxValue">Valor m�ximo permitido.</param>
    /// <param name="currentValue">Valor inicial de la estad�stica.</param>
    protected Stats(float minValue, float maxValue, float currentValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        OnValueChanged?.Invoke(this.currentValue, this.maxValue);
    }

    /// <summary>
    /// Propiedad para obtener o establecer el valor m�ximo de la estad�stica.
    /// Solo accesible desde clases derivadas.
    /// </summary>
    public float MaxValue
    {
        get { return maxValue; }
        protected set { maxValue = value; }
    }

    /// <summary>
    /// Propiedad de solo lectura para obtener el valor actual de la estad�stica.
    /// </summary>
    public float CurrentValue => currentValue;

    /// <summary>
    /// Modifica el valor actual de la estad�stica, asegurando que permanezca entre el m�nimo y el m�ximo.
    /// Dispara el evento OnValueChanged si hay cambios.
    /// </summary>
    /// <param name="amount">Cantidad a modificar (puede ser positiva o negativa).</param>
    public virtual void ModifyValue(float amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, minValue, maxValue);
        OnValueChanged?.Invoke(currentValue, maxValue);
    }
}
