using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : Card
{
    protected Spells()
    {
        typeOfCard = CardType.Spell;
    }

    public override void PlayCard()
    {   
        base.PlayCard();
        PlaySpell();
        
    }

   


    public abstract void PlaySpell();
}
