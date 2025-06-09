using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "HealingSkill", menuName = "Scriptable Objects/HealingSkill")]
public class HealingSkill : Skill
{
    [SerializeField] private LifeSystem life;
    public override bool CanUse(ManaSystem mana, bool drawn)
    {
        return drawn && mana.CurrentMana >= Cost && life.CurrentValue < life.MaxValue;
    }

    public override void Use(GameObject user, ManaSystem mana)
    {
        user.GetComponent<MonoBehaviour>().StartCoroutine(HealOvertime(mana));
    }
    private IEnumerator HealOvertime(ManaSystem mana)
    {
        float healed = 0;
        while (CanUse(mana, true) && healed < life.MaxValue)
        {
            mana.SpendMana((int)Cost);
            life.Heal(HealAmount);
            healed += HealAmount;
            SkillUsed();
            yield return new WaitForSeconds(5);
        }
    }
}
