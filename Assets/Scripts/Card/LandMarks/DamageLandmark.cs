using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Landmarks/DamageLandmark")]
public class DamageLandmark : Landmarks
{
    public DamageLandmark(DamageLandmark card) : base(card.minionHealth, card.name, card.description, card.artwork, card.manaCost, card.tag)
    {

    }

    public override void PlaceLandmark()
    {
        Target.tenExtraDamage += 1;
        LandmarkTarget.tenExtraDamage += 1;
    }
    public override void LandmarkEffectTakeBack()
    {
        Target.tenExtraDamage -= 1;
        LandmarkTarget.tenExtraDamage -= 1;
    }

}
