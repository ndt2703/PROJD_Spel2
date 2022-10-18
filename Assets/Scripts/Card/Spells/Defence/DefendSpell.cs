using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Spells/DefenceSpell")]
public class DefendSpell : Spells
{
    public int defence;
    public bool allChampions;

    public override void PlaySpell()
    {
        if (allChampions)
        {
            foreach (AvailableChampion champ in FindObjectsOfType<AvailableChampion>())
            {
                champ.GainShield(defence);
            }
        }
        else
        {
            Target.GainShield(defence);
        }       
    }
}
