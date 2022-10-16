using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Spells/HealChampion")]
public class HealChampion : Spells
{
    public int amountToHeal;
    public bool allChampions;
    public override void PlaySpell()
    {
        if (allChampions)
        {
            foreach (Champion champ in FindObjectsOfType<Champion>())
            {
                champ.HealChampion(amountToHeal);
            }
        }
        else
        {
            FindObjectOfType<Champion>().HealChampion(amountToHeal);
        }
    }
}
