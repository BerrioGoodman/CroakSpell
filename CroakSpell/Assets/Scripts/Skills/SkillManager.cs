using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private List<Skill> skills;
    [SerializeField] private LifeSystem life;
    [SerializeField] private ManaSystem mana;
    [SerializeField] private List<SkillUI> skillUI;
    [SerializeField] private PlayerController controller;
    private float[] cooldownTimers;
    private void Awake()
    {
        cooldownTimers = new float[skills.Count];
    }
    void Update()
    {
        for (int i = 0; i < cooldownTimers.Length; i++)
        {
            cooldownTimers[i] = Time.deltaTime;
            float fill = 1 - (cooldownTimers[i] / skills[i].Cooldown);//This is for the UI
            skillUI[i].SetCooldownFill(fill);
        }
    }
    public void ActivateSkill(int index)
    {
        if (index < 0 || index >= skills.Count) return;
        Skill skill = skills[index];
        if (cooldownTimers[index] <= 0 && skill.CanUse(mana, Drawn.isDrawn))
        {
            skill.Use(gameObject, mana);
            cooldownTimers[index] = skill.Cooldown;
            skillUI[index].SetCooldownFill(10);
        }
    }
}
