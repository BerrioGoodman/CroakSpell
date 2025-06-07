using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HUDView : BaseView
{
    [Header("UI References")]
    [SerializeField] private Slider lifeBar;
    [SerializeField] private Slider manaBar;

    //cambia la visibilidad del HUD de la vida
    public void SetHeal(float value, float max)
    {
        lifeBar.maxValue = max;
        lifeBar.value = value;
    }

    //cambia la visibilidad del HUD del maná
    public void SetMana(float value, float max)
    {
        manaBar.maxValue = max;
        manaBar.value = value;
    }
}
