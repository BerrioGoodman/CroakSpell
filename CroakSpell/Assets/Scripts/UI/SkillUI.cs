using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image iconCooldown;
    public void SetSkillIcon(Sprite figure)
    {
        if (icon) icon.sprite = figure;
    }
    public void SetCooldownFill(float fill)
    {
        if (iconCooldown) iconCooldown.fillAmount = 1 - fill;
    }
}
