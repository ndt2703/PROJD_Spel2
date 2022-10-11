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
        //  GameLoop.Instance.DrawCard(amountOfCardsToDraw);

        RequestDrawCard request = new RequestDrawCard(amountOfCardsToDraw);

        ClientConnection.Instance.AddRequest(request, GameLoop.Instance.DrawCardRequest);
    }


    public abstract void PlaySpell();
}
