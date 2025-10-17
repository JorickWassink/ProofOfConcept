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
    private void Update()
    {
        if (characterInfo.hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float attackerDamage) => characterInfo.hp -= attackerDamage;
}