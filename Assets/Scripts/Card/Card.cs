using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
public enum CardType
{
    Spell,
    Landmark
};

public abstract class Card : ScriptableObject
{
    public string cardName;
    public CardType typeOfCard;
    public string description;

    public Sprite artwork;
    public int manaCost;

    public string tag;   

    private Champion target;
    private LandmarkDisplay landmarkTarget;

    public int amountOfCardsToDraw = 0;
    public int amountOfCardsToDiscard = 0;
    public bool discardCardsYourself = true;
  
    public Champion Target { get { return target; } set { target = value; } }
    public LandmarkDisplay LandmarkTarget { get { return landmarkTarget; } set { landmarkTarget = value; } }

    public virtual void PlayCard()
    {

        Debug.Log("kommer den till play card");
        CardAndPlacement cardPlacement = new CardAndPlacement();
        cardPlacement.cardName = cardName;
        Debug.Log("Vilket namn hade kortet yo " + cardPlacement.cardName);
        
        TargetInfo placement = new TargetInfo();
        placement.whichList = new ListEnum();
        placement.index = 100;

        if (typeOfCard != CardType.Landmark)
        {
            ListEnum tempEnum = new ListEnum();
            tempEnum.myGraveyard = true;
            placement.whichList = tempEnum;
            placement.index = 100;
        }
        RequestPlayCard playCardRequest = new RequestPlayCard(cardPlacement);
        playCardRequest.whichPlayer = ClientConnection.Instance.playerId;
        if (GameState.Instance.isOnline)
        {
            ClientConnection.Instance.AddRequest(playCardRequest, GameState.Instance.RequestPlayCard);
        }


        
        if (amountOfCardsToDraw != 0)
        {
            DrawCard();
        }
        if (amountOfCardsToDiscard != 0)
        {
            DiscardCard();
        }
    }

    private void DiscardCard()
    {

        if (GameState.Instance.isOnline)
        {
            if(discardCardsYourself)
            {
                RequestDiscardCard request = new RequestDiscardCard();
                request.whichPlayer = ClientConnection.Instance.playerId;
                List<string> cardsDiscarded = new List<string>();
                for (int i = 0; i < amountOfCardsToDiscard; i++)
                {
                    cardsDiscarded.Add( GameState.Instance.DiscardCard(discardCardsYourself));
                }
                request.listOfCardsDiscarded = cardsDiscarded; 

                ClientConnection.Instance.AddRequest(request, GameState.Instance.RequestDiscardCard);
            }
            else
            {
                RequestOpponentDiscardCard requesten = new RequestOpponentDiscardCard();
                requesten.whichPlayer = ClientConnection.Instance.playerId;
                requesten.amountOfCardsToDiscard = amountOfCardsToDiscard;
                ClientConnection.Instance.AddRequest(requesten, GameState.Instance.RequestDiscardCard);

            }
        }
        else
        {
            for (int i = 0; i < amountOfCardsToDiscard; i++)
            {
                GameState.Instance.DiscardCard(discardCardsYourself);
            }
        }
    }

    private void DrawCard()
    {
        //  ActionOfPlayer.Instance.DrawCard(amountOfCardsToDraw);
        if (GameState.Instance.isOnline)
        {
            RequestDrawCard request = new RequestDrawCard(amountOfCardsToDraw);
            request.whichPlayer = ClientConnection.Instance.playerId;
            ClientConnection.Instance.AddRequest(request, GameState.Instance.DrawCardRequest);
        }
        else
        {
            GameState.Instance.DrawCard(amountOfCardsToDraw);
        }
    }


}
