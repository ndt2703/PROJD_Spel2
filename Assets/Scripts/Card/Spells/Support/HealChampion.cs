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
            foreach (AvailableChampion champ in FindObjectsOfType<AvailableChampion>())
            {
                champ.HealChampion(amountToHeal);
            }
        }
        else
        {
            FindObjectOfType<AvailableChampion>().HealChampion(amountToHeal);
        }
    }
}
