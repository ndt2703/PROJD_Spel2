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
            foreach (AvailableChampion champ in GameState.Instance.playerChampions)
            {
                champ.champion.HealChampion(amountToHeal);
            }
        }
        else
        {
            Target.HealChampion(amountToHeal);
        }
    }
}
