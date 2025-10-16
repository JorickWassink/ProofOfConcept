using System;
using UnityEngine;
using TMPro;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float range;
    [SerializeField] protected float damage;
    [SerializeField] public readonly float percentDamageBonus;
    [SerializeField] public readonly float percentDamageReduction;
    [SerializeField] private GameObject floatingTextPrefab;

    public Facing facing;
    public event Func<Facing, float> DamageBonus;
    public event Func<Facing, float> DamageReduction;

    public void TakeDamage(Facing attackerFacing, float attackerDamage)
    {
        float finalDamage = attackerDamage * (DamageReduction?.Invoke(attackerFacing) ?? 1f);
        hp -= finalDamage;

        // Spawn floating text
        if (floatingTextPrefab != null)
        {
            var text = Instantiate(floatingTextPrefab, transform.position + Vector3.up * 1.2f, Quaternion.identity);
            var ft = text.GetComponent<FloatingText>();
            if (ft != null)
                ft.Initialize($"-{Mathf.RoundToInt(finalDamage)} ({Mathf.RoundToInt(hp)} HP)", Color.red);
        }

        Debug.Log($"{gameObject.name} took {finalDamage} damage, {hp} HP left");
    }

    public float DoDamage(Facing targetFacing) => damage *= ((DamageBonus?.Invoke(targetFacing) ?? 0f) + SupriceAttack(targetFacing));

    public float SupriceAttack(Facing secondCharacterFacing)
    {
        if (secondCharacterFacing == facing) return 0.1f;
        else return 0f;
    }
}
