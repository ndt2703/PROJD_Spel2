using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<GameObject> cardSlotsInHand = new List<GameObject>();
    public Deck deck;
    public List<GameObject> cardsInHand = new List<GameObject>();

    private void FixedUpdate()
    {

        foreach (GameObject cardSlot in cardSlotsInHand)
        {
            CardDisplay cardDisplay = cardSlot.GetComponent<CardDisplay>();
            if (cardDisplay.card != null)
            {
                if (!cardsInHand.Contains(cardSlot))
                    cardsInHand.Add(cardSlot);
            }
            else
            {
                cardSlot.SetActive(false);
                if (cardsInHand.Contains(cardSlot))
                    cardsInHand.Remove(cardSlot);
            }
            
        }
    }

    public void DiscardRandomCardInHand()
    {
        
        int cardIndex = Random.Range(0, cardsInHand.Count);
        print(cardsInHand.Count);
        CardDisplay cardDisplay = cardsInHand[cardIndex].GetComponent<CardDisplay>();
        print(cardDisplay.card);
        Graveyard.Instance.AddCardToGraveyard(cardDisplay.card);
        cardDisplay.card = null;
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
