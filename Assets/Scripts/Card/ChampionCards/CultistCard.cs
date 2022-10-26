using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/ChampionCards/Cultist")]
public class CultistCard : Spells
{
    [Header("RitualSacrifice")]
    public int selfInflictDamage = 0;
    [Header("Deluge")]
    public bool damageToAllOpponentCards;
    public int damageToDealToAllOpponent = 0;
    public override void PlaySpell()
    {
        GameState gameState = GameState.Instance;
        gameState.playerChampion.champion.TakeDamage(selfInflictDamage);

        if (damageToAllOpponentCards)
        {
            gameState.opponentChampion.champion.TakeDamage(damageToDealToAllOpponent);
            foreach (Landmarks landmark in gameState.opponentLandmarks)
            {
                landmark.TakeDamage(damageToDealToAllOpponent);
            }           
        }
    }
}
