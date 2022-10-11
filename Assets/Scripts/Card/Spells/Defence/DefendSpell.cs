using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Spells/DefenceSpell")]
public class DefendSpell : Spells
{
    public int defence;

    public override void PlaySpell()
    {
        FindObjectOfType<Champion>().GainShield(defence);
    }
}