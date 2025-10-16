using UnityEngine;

public class Archer:MonoBehaviour 
{
    BaseCharacter character;
    private void Start()
    {
        character = gameObject.GetComponent<BaseCharacter>();
        character.DamageBonus += DamageBonus;
        character.DamageReduction += DamageReduction;
    }
    public float DamageBonus(Facing targetFacing) => 1f;
    public float DamageReduction(Facing attackerFacing) => 1f;
}
