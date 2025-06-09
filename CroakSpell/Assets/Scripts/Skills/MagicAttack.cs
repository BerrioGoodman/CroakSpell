using UnityEngine;

[CreateAssetMenu(fileName = "MagicAttack", menuName = "Scriptable Objects/MagicAttack")]
public class MagicAttack : Skill
{
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private float sphereSpeed;

    public override bool CanUse(ManaSystem mana, bool drawn)
    {
        return drawn && mana.CurrentMana >= Cost;
    }

    public override void Use(GameObject user, ManaSystem mana)
    {
        if (!CanUse(mana, true)) return;
        mana.SpendMana((int)Cost);
        GameObject bullet = Instantiate(spherePrefab, user.transform.position + user.transform.forward, Quaternion.identity);
        bullet.GetComponent<Bullet>().Initialize(Damage, sphereSpeed, user.transform.forward);
        SkillUsed();
    }
}
