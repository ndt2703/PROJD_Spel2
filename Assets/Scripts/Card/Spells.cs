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
        //  GameLoop.Instance.DrawCard(amountOfCardsToDraw);

        RequestDrawCard request = new RequestDrawCard(amountOfCardsToDraw);

        request.whichPlayer = ClientConnection.Instance.playerId;

        ClientConnection.Instance.AddRequest(request, GameLoop.Instance.DrawCardRequest);
        Debug.Log(request.Type);
    }


    public abstract void PlaySpell();
}
