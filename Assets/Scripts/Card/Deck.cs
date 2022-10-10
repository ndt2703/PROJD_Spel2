using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Stack<Card> deckOfCards = new Stack<Card>();

    public void AddCardToDeck(Card cardToAdd)
    {
        deckOfCards.Push(cardToAdd);
    }

    public Card WhichCardToDraw()
    {
        return deckOfCards.Pop();
    }
}
