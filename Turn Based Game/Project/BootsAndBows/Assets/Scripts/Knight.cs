using UnityEngine;

public class Knight: MonoBehaviour
{
    [SerializeField] float seccondPercentDamageReduction;
    BaseCharacter character;
    private void Start()
    {
        character = gameObject.GetComponent<BaseCharacter>();
        character.DamageBonus += DamageBonus;
        character.DamageReduction += DamageReduction;
    }
    public float DamageBonus(Facing targetFacing) => 1f;
    public float DamageReduction(Facing attackerFacing)
    {
        if (attackerFacing + 2 % 4 == character.facing) return character.percentDamageReduction;
        else return seccondPercentDamageReduction;
    }
}
