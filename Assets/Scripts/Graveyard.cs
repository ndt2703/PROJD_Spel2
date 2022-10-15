using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour
{
    public List<Card> graveyardCardList = new List<Card>();

    public void AddCardToGraveyard(Card cardToAdd)
    {
        graveyardCardList.Add(cardToAdd);
    }

    public Card RandomizeCardFromGraveyard()
    {
        return FindAndRemoveCardInGraveyard(graveyardCardList[Random.Range(0, graveyardCardList.Count)]);
    }

    public Card FindAndRemoveCardInGraveyard(Card cardToReturn)
    {       
        foreach (Card card in graveyardCardList)
        {
            if (card == cardToReturn)
            {
                graveyardCardList.Remove(card);
                return card;
            }
        }
        return null;
    }
}
