using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Stack<Card> deckOfCards = new Stack<Card>();

    public List<Card> allCardsAvailable = new List<Card>();



    void Shuffle(List<Card> list)
    {
        int n = list.Count;
        while (n > 1) //Randomizes the list
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
    }


    private void Start()
    {
        //string ha = "D:/Skola/PROJD/PROJD_Spel2/Assets/ScriptableObjects";
        //
        //
        Shuffle(allCardsAvailable);
        

        while (deckOfCards.Count < 60)
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
