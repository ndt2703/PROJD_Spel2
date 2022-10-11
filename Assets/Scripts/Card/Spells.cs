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
    }

    private void DrawCard()
    {
        GameState.Instance.DrawCardToHand(amountOfCardsToDraw);
    }

    public abstract void PlaySpell();
}
