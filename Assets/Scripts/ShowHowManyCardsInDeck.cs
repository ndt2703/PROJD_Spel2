using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHowManyCardsInDeck : MonoBehaviour
{
    [SerializeField] private GameObject howManyCardsPanel;
    [SerializeField] private TMP_Text amountOfCardsText;

    private Deck deck;

    private void Awake()
    {
        deck = GetComponent<Deck>();
    }

    private void OnMouseEnter()
    {
        amountOfCardsText.text = "You have " + deck.deckOfCards.Count + " Cards in your deck";
        howManyCardsPanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        howManyCardsPanel.SetActive(false);
    }
}
