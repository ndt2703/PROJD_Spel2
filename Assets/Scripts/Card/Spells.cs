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
        GameState gameState = GameState.Instance;
        for (int i = 0; i < amountOfCardsToDiscard; i++)
        {
            gameState.DiscardCard();
        }


        
    }

    private void DrawCard()
    {
        //  ActionOfPlayer.Instance.DrawCard(amountOfCardsToDraw);

        RequestDrawCard request = new RequestDrawCard(amountOfCardsToDraw);

        request.whichPlayer = ClientConnection.Instance.playerId;

        ClientConnection.Instance.AddRequest(request, GameState.Instance.DrawCardRequest);
        Debug.Log(request.Type);
    }


    public abstract void PlaySpell();
}
