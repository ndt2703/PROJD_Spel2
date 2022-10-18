using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Spells/AttackSpell")]
public class AttackSpell : Spells
{
    public int damage = 10;


    public override void PlaySpell()
    {
        Target.TakeDamage(damage);
    }
}
