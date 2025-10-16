using UnityEngine;

public class Bandit: MonoBehaviour
{

    BaseCharacterInfo character;
    private void Start()
    {
        character = gameObject.GetComponent<BaseCharacterInfo>();
        gameObject.GetComponent<BaseCharracterAttack>().DamageBonus += DamageBonus;
        gameObject.GetComponent<BaseCharracterTakeDamage>().DamageReduction += DamageReduction;
    }
    public float DamageReduction(Facing attackerFacing)
    {
        if(character.facing == attackerFacing) return character.percentDamageReduction;
        else return 1;
    }

    public float DamageBonus(Facing targetFacing)
    {
        if (character.facing == targetFacing) return character.percentDamageBonus;
        else return 1;
    }
}
