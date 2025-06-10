using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private PlayerStats playerStats;

    [Header("Referencias UI")]
    [SerializeField] private ManaBarView manaBarView;
    [SerializeField] private LifeBarView lifeBarView;

    /// <summary>
    /// Inicializa las estadísticas del jugador y suscribe los eventos de cambio de vida y maná
    /// a las vistas correspondientes de la UI.
    /// </summary>
    private void Awake()
    {
        playerStats = new PlayerStats();
        playerStats.OnLifeChanged += lifeBarView.UpdateLifeBar;
        playerStats.OnManaChanged += manaBarView.UpdateManaBar;
    }

    /// <summary>
    /// Actualiza las barras de vida y maná al valor inicial al comenzar la escena.
    /// </summary>
    private void Start()
    {
        lifeBarView.UpdateLifeBar(playerStats.Life.CurrentValue, playerStats.Life.MaxValue);
        manaBarView.UpdateManaBar(playerStats.Mana.CurrentValue, playerStats.Mana.MaxValue);
    }

    /// <summary>
    /// Desuscribe los eventos al destruir el objeto para evitar fugas de memoria.
    /// </summary>
    private void OnDestroy()
    {
        if (playerStats != null)
        {
            playerStats.OnLifeChanged -= lifeBarView.UpdateLifeBar;
            playerStats.OnManaChanged -= manaBarView.UpdateManaBar;
        }
    }

    /// <summary>
    /// Recarga automáticamente el maná del jugador cada frame según la velocidad de recarga.
    /// </summary>
    private void Update()
    {
        float timeToRechargeMana = Time.deltaTime * playerStats.Mana.SpeedRecharge;
        playerStats.Mana.Recharge(timeToRechargeMana);
    }

    /// <summary>
    /// Cura al jugador en la cantidad especificada.
    /// </summary>
    /// <param name="amount">Cantidad de vida a curar.</param>
    public void HealPlayer(float amount)
    {
        playerStats.Life.Heal(amount);
    }

    /// <summary>
    /// Daña al jugador en la cantidad especificada.
    /// </summary>
    /// <param name="amount">Cantidad de daño a recibir.</param>
    public void TakeDamage(float amount)
    {
        playerStats.Life.TakeDamage(amount);
    }

    /// <summary>
    /// Recarga el maná del jugador en la cantidad especificada.
    /// </summary>
    /// <param name="amount">Cantidad de maná a recargar.</param>
    public void RechargeMana(float amount)
    {
        playerStats.Mana.Recharge(amount);
    }

    /// <summary>
    /// Intenta gastar una cantidad de maná. Devuelve true si fue posible, false si no hay suficiente maná.
    /// </summary>
    /// <param name="cost">Cantidad de maná a gastar.</param>
    /// <returns>True si se pudo gastar el maná, false en caso contrario.</returns>
    public bool TrySpendMana(int cost)
    {
        if (playerStats.Mana.CurrentValue >= cost)
        {
            playerStats.Mana.SpendMana(cost);
            return true;
        }

        return false;
    }
}
