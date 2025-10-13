using UnityEngine;
[CreateAssetMenu(fileName = "Archer", menuName = "Charracters/Archer")]
public class Archer:BaseCharacter
{

    public override float DamageBonus(Facing targetFacing) => 1f;
    public override float DamageReduction(Facing attackerFacing) => 1f;
}
