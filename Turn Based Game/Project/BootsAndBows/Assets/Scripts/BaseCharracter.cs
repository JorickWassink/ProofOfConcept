using System;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float range;
    [SerializeField] protected float damage;
    [SerializeField] public readonly float percentDamageBonus;
    [SerializeField] public readonly float percentDamageReduction;
    public Facing facing;
    public event Func<Facing, float> DamageBonus;
    public event Func<Facing, float> DamageReduction;

    public void TakeDamage(Facing attackerFacing, float attackerDamage) => hp -= attackerDamage * (DamageReduction?.Invoke(attackerFacing) ?? 0f);
    public float DoDamage(Facing targetFacing) => damage *= ((DamageBonus?.Invoke(targetFacing) ?? 0f) + SupriceAttack(targetFacing));
    public float SupriceAttack(Facing seccondCharacterFacing)
    {
        if (seccondCharacterFacing == facing) return 0.1f;
        else return 0f;
    }
}
