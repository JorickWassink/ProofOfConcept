using System;
using UnityEngine;

public class BaseCharracterAttack: MonoBehaviour
{
    BaseCharacterInfo characterInfo;

    public event Func<Facing, float> DamageBonus;
    private void Start()
    {
        characterInfo = gameObject.GetComponent<BaseCharacterInfo>();
    }
    public float DoDamage(Facing targetFacing) => characterInfo.damage *= ((DamageBonus?.Invoke(targetFacing) ?? 0f) + SupriceAttack(targetFacing));
    public float SupriceAttack(Facing seccondCharacterFacing)
    {
        if (seccondCharacterFacing == characterInfo.facing) return 0.1f;
        else return 0f;
    }
}