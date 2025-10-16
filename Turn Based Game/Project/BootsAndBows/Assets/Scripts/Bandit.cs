using UnityEngine;

public class Bandit:MonoBehaviour
{
    BaseCharacter character;
    private void Start()
    {
        character = gameObject.GetComponent<BaseCharacter>();
        character.DamageBonus += DamageBonus;
        character.DamageReduction += DamageReduction;
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
