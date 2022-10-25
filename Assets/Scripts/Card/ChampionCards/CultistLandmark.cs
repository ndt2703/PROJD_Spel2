using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/ChampionCards/CultistLandmark")]
public class CultistLandmark : Landmarks
{
    public CultistLandmark(CultistLandmark card) : base(card.minionHealth, card.name, card.description, card.artwork, card.manaCost, card.tag) { }

    public override void PlaceLandmark()
    {
            GameState.Instance.occultGathering++;
    }

    public override void LandmarkEffectTakeBack()
    {
            GameState.Instance.occultGathering--;
    }
}
