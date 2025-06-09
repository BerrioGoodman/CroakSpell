using UnityEngine;
[CreateAssetMenu(fileName = "MeleeAttack", menuName = "Scriptable Objects/MeleeAttack")]
public class MeleeAttack : Skill
{
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemy;

    public override bool CanUse(ManaSystem mana, bool drawn) => drawn;

    public override void Use(GameObject user, ManaSystem mana)
    {
        if (!CanUse(mana, true)) return;
        Collider[] hits = Physics.OverlapSphere(user.transform.position + user.transform.forward, attackRange, enemy);
        foreach (Collider hit in hits)
        {
            var enemy = hit.GetComponent<DummyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
        SkillUsed();
    }
}
