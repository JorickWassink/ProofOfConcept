using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float range;
    [SerializeField] protected float damage;
    [SerializeField] protected float percentDamageBonus;
    [SerializeField] protected float percentDamageReduction;
    public Facing facing;
    private void Start()
    {
        Attack attackScript = gameObject.GetComponent<Attack>();
        attackScript.attack += DoDamage;
        attackScript.facing += () => facing;
        attackScript.damage += TakeDamage;
    }
    public abstract float DamageBonus(Facing targetFacing);
    public abstract float DamageReduction(Facing attackerFacing);
    public void TakeDamage(Facing attackerFacing, float attackerDamage) => hp -= attackerDamage * DamageReduction(attackerFacing);
    public float DoDamage(Facing targetFacing) => damage *= (DamageBonus(targetFacing) + SupriceAttack(targetFacing));
    public float SupriceAttack(Facing seccondCharacterFacing)
    {
        if (seccondCharacterFacing == facing) return 0.1f;
        else return 0f;
    }
}
