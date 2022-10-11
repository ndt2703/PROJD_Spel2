using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Spells/HealBenchedChampion")]
public class HealBenchedChampion : Spells
{
    public int amountToHeal;
    public override void PlaySpell()
    {
        FindObjectOfType<Champion>().HealChampion(amountToHeal);
    }
}
