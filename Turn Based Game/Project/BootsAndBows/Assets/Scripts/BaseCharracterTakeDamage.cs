using System;
using UnityEngine;

public class BaseCharracterTakeDamage: MonoBehaviour
{
    BaseCharacterInfo characterInfo;

    public event Func<Facing, float> DamageReduction;
    private void Start()
    {
        characterInfo = gameObject.GetComponent<BaseCharacterInfo>();
    }

    public void TakeDamage(Facing attackerFacing, float attackerDamage) => characterInfo.hp -= attackerDamage * (DamageReduction?.Invoke(attackerFacing) ?? 0f);
}