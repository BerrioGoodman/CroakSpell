using UnityEngine;

public class HUDController : BaseController
{
    //Recibimos los datos y comunicamos con la vista
    private HUDView Hudview;
    private PlayerStats playerStats;
    public HUDController(HUDView View, bool init, PlayerStats PlayerStats) : base(View, init)
    {
        this.Hudview = View;
        this.playerStats = PlayerStats;
    }

    public override void Initialize()
    {
        playerStats.OnLifeChanged += OnLifeChanged;
        playerStats.OnManaChanged += OnManaChanged;
    }

    private void OnLifeChanged(float current, float max)
    {
        Hudview.SetHeal(current, max);
    }

    private void OnManaChanged(float current, float max)
    {
        Hudview.SetMana(current, max);
    }
}
