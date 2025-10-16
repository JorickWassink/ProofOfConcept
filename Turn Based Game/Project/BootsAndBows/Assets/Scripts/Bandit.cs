using UnityEngine;

public class Bandit: BaseCharacter
{
    public override float DamageReduction(Facing attackerFacing)
    {
        if(facing == attackerFacing) return percentDamageReduction;
        else return 1;
    }

    public override float DamageBonus(Facing targetFacing)
    {
        if (facing == targetFacing) return percentDamageBonus;
        else return 1;
    }
}
