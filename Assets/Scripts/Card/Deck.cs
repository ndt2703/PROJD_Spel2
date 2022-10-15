using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Stack<Card> deckOfCards = new Stack<Card>();

    public List<Card> allCardsAvailable = new List<Card>();


    private void Start()
    {
        string ha = "D:/Skola/PROJD/PROJD_Spel2/Assets/ScriptableObjects";


        while (deckOfCards.Count < 30)
        {
            foreach (Card card in allCardsAvailable)
            {
                deckOfCards.Push(card);
            }
        }

    }



    public void AddCardToDeck(Card cardToAdd)
    {
        deckOfCards.Push(cardToAdd);
    }

    public Card WhichCardToDraw()
    {
        return deckOfCards.Pop();
    }
}
