using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/ChampionCards/TheOneWhoDrawsLandmark")]
public class TheOneWhoDrawsLandmark : Landmarks
{
    public TheOneWhoDrawsLandmark(TheOneWhoDrawsLandmark card) : base(card.minionHealth, card.cardName, card.description, card.artwork, card.manaCost, card.tag)
    {

    }

    public override void PlaceLandmark()
    {
        GameState.Instance.SwapActiveChampion(null);
    }
}
