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

/*    public HealingLandmark(bool dHE, int mH, string name, string desc, Sprite art, int mana, string tag) : base()
    {
        this.doubleHealingEffect = dHE;
        this.minionHealth = mH;
        this.name = name;
        this.description = desc;
        this.artwork = art;
        this.manaCost = mana;
        this.tag = tag;
    }*/

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
