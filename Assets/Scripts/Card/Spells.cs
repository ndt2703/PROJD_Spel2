using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : Card
{
    public int amountOfCardsToDraw;
    public override void PlayCard()
    {
        PlaySpell();
        if (amountOfCardsToDraw != 0)
            DrawCard();
        GameLoop.Instance.MakeCardSpellTag();
    }

    private void DrawCard()
    {
        GameLoop.Instance.DrawCardToHand(amountOfCardsToDraw);
    }


    public abstract void PlaySpell();
}
