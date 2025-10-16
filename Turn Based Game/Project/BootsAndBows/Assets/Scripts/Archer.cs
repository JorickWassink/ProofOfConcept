using UnityEngine;

public class Archer:BaseCharacter
{

    public override float DamageBonus(Facing targetFacing) => 1f;
    public override float DamageReduction(Facing attackerFacing) => 1f;
}
