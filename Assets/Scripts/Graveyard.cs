using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour
{
    public List<Card> graveyardPlayer = new List<Card>();
    public List<Card> graveyardOpponent = new List<Card>();

    private static Graveyard instance;
    public static Graveyard Instance { get { return instance; } }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCardToGraveyard(Card cardToAdd)
    {
        graveyardPlayer.Add(cardToAdd);
    }

    public Card RandomizeCardFromGraveyard()
    {
        return FindAndRemoveCardInGraveyard(graveyardPlayer[Random.Range(0, graveyardPlayer.Count)]);
    }

    public Card FindAndRemoveCardInGraveyard(Card cardToReturn)
    {       
        foreach (Card card in graveyardPlayer)
        {
            if (card == cardToReturn)
            {
                graveyardPlayer.Remove(card);
                return card;
            }
        }
        return null;
    }

    public void AddCardToGraveyardOpponent(Card cardToAdd)
    {
        graveyardOpponent.Add(cardToAdd);
    }

    public Card RandomizeCardFromGraveyardOpponent()
    {
        return FindAndRemoveCardInGraveyardOpponent(graveyardOpponent[Random.Range(0, graveyardOpponent.Count)]);
    }

    public Card FindAndRemoveCardInGraveyardOpponent(Card cardToReturn)
    {
        foreach (Card card in graveyardOpponent)
        {
            if (card == cardToReturn)
            {
                graveyardOpponent.Remove(card);
                return card;
            }
        }
        return null;
    }
}
