using System;
using UnityEngine;

public class BaseCharacterInfo  
{
    [SerializeField] public float hp;
    [SerializeField] public float range;
    [SerializeField] public float damage;
    [SerializeField] public readonly float percentDamageBonus;
    [SerializeField] public readonly float percentDamageReduction;
    public Facing facing;
}
