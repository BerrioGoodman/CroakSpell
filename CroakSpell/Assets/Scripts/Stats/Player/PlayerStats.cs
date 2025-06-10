using System;

public class PlayerStats
{
    public LifeSystem Life { get; private set; }

    public ManaSystem Mana { get; private set; }

    /// <summary>
    /// Evento que se dispara cuando la vida del jugador cambia.
    /// Proporciona el valor actual y el máximo de vida.
    /// </summary>
    public event Action<float, float> OnLifeChanged;

    /// <summary>
    /// Evento que se dispara cuando el maná del jugador cambia.
    /// Proporciona el valor actual y el máximo de maná.
    /// </summary>
    public event Action<float, float> OnManaChanged;

    /// <summary>
    /// Constructor que inicializa los sistemas de vida y maná,
    /// y suscribe los eventos internos a los eventos públicos.
    /// </summary>
    public PlayerStats()
    {
        Life = new LifeSystem(0, 100, 100);
        Mana = new ManaSystem(0, 100, 100, 1f);

        Life.OnValueChanged += (current, max) => OnLifeChanged?.Invoke(current, max);
        Mana.OnValueChanged += (current, max) => OnManaChanged?.Invoke(current, max);
    }
}
