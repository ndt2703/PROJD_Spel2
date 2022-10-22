using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Landmarks/DamageLandmark")]
public class DamageLandmark : Landmarks
{
    public int damage;

    public DamageLandmark(DamageLandmark card) : base(card.minionHealth, card.name, card.description, card.artwork, card.manaCost, card.tag)
    {
        damage = card.damage;
    }

    public override void PlaceLandmark()
    {

    }


}
