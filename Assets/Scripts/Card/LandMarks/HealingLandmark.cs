using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Landmarks/HealingLandmark")]
public class HealingLandmark : Landmarks
{
    public bool doubleHealingEffect = false;

    public HealingLandmark(HealingLandmark card) : base(card.minionHealth,card.name,card.description,card.artwork,card.manaCost,card.tag)
    {
        doubleHealingEffect = card.doubleHealingEffect;
    }

    public override void PlaceLandmark()
    {
        if (doubleHealingEffect)
        {
            foreach (Champion champ in GameState.Instance.playerChampions)
            {
                champ.GetComponent<AvailableChampion>().landmarkEffect *= 2;
            }
        }
    }

    
}
