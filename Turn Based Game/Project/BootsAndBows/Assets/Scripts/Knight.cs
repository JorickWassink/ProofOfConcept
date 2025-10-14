using UnityEngine;

public class Knight: BaseCharacter
{
    [SerializeField] float seccondPercentDamageReduction;
   
    public override float DamageBonus(Facing targetFacing) => 1f;
    public override float DamageReduction(Facing attackerFacing)
    {
        if (attackerFacing + 2 % 4 == facing) return percentDamageReduction;
        else return seccondPercentDamageReduction;
    }
}
