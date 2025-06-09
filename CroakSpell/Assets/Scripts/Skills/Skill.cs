using System;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public event Action OnSkillUsed;
    [SerializeField] private string name;
    [SerializeField] private float cooldown;
    [SerializeField] private float cost;
    [SerializeField] private float damage;
    [SerializeField] private float healAmount;
    public string Name => name;
    public float Cooldown => cooldown;
    public float Cost => cost;
    public float Damage => damage;
    public float HealAmount => healAmount;
    public abstract bool CanUse(ManaSystem mana, bool drawn);
    public abstract void Use(GameObject user, ManaSystem mana);
    protected void SkillUsed()
    {
        OnSkillUsed?.Invoke();
    }
}
