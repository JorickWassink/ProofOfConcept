using UnityEngine;

public class Archer:MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<BaseCharracterAttack>().DamageBonus += (Facing targetFacing) => 1f;
        gameObject.GetComponent<BaseCharracterTakeDamage>().DamageReduction += (Facing attackerFacing) => 1f;
    }
}
