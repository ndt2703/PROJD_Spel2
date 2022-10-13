using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHowManyCardsInDeck : MonoBehaviour
{
    [SerializeField] private GameObject howManyCardsPanel;
    [SerializeField] private TMP_Text amountOfCardsText;

    private Deck deck;
    private Graveyard graveyard;

    private void Awake()
    {
        if (GetComponent<Deck>() != null)
            deck = GetComponent<Deck>();
        else if (GetComponent<Graveyard>() != null)
            graveyard = GetComponent<Graveyard>();
    }

    private void OnMouseEnter()
    {
        if (deck != null)
            amountOfCardsText.text = "You have " + deck.deckOfCards.Count + " Cards in your deck";
        else if (graveyard != null)
            amountOfCardsText.text = "You have " + graveyard.graveyardCardList.Count + " Cards in your graveyard";
        howManyCardsPanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        howManyCardsPanel.SetActive(false);
    }
}
