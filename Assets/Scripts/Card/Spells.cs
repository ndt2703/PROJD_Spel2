using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : Card
{
    public int amountOfCardsToDraw;
    public int amountOfCardsToDiscard;
    public override void PlayCard()
    {
        PlaySpell();
        if (amountOfCardsToDraw != 0)
            DrawCard();
        if (amountOfCardsToDiscard != 0)
            DiscardCard();
    }

    private void DiscardCard()
    {
        GameLoop gameLoop = GameLoop.Instance;
        for (int i = 0; i < amountOfCardsToDiscard; i++)
        {
            gameLoop.DiscardCard();
        }
        
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
