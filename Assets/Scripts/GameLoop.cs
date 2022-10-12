using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public int playerMana;
    public GameObject handGO;
    public GameObject handOponentGO;
    public bool isPlayerOnesTurn;

    private Hand handPlayer;
    private Hand handOpponent;

    public int amountOfTurns;
    [SerializeField] private int amountOfCardsToStartWith;

    public bool playerOneStarted;

    private static GameLoop instance;

    public static GameLoop Instance { get { return instance; } set { instance = value; } }
    private int cardCost;

    private void Awake()
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
    private void Start()
    {
        float random = Random.Range(0,1);

        handPlayer = handGO.GetComponent<Hand>();
        handOpponent = handOponentGO.GetComponent<Hand>();

        if (random == 0)
            playerOneStarted = true;
        else if (random == 1)
            playerOneStarted = false;
        Invoke(nameof(DrawStartingCards), 0.1f);
    }

    public void AmountOfManaToGivePlayer()
    {
        playerMana = amountOfTurns;
    }

    public void EndTurn()
    {
        if (isPlayerOnesTurn)
        {
            isPlayerOnesTurn = false;
            if (!playerOneStarted)
            {
                amountOfTurns++;
            }
        }
        else
        {
            isPlayerOnesTurn = true;
            if (playerOneStarted)
            {
                amountOfTurns++;
            }
            
        }
    }

    public void DrawStartingCards()
    {
        DrawCard(amountOfCardsToStartWith);
    }

    public void DrawCardToHand(int amountToDraw)
    {
        DrawCard(amountToDraw);
    }

    public void MakeCardSpellTag()
    {

    }

    public void CheckIfCanPlayCard(Card card)
    {
        cardCost = card.manaCost;
        if (playerMana >= cardCost)
        {
            playerMana -= cardCost;
            card.PlayCard();
            
        }
        else
        {
            Debug.Log("You don't have enough Mana");
        }
    }

    public void DrawCardRequest(ServerResponse response)
    {

        DrawCard(2);
    }

    public void DrawCard(int amountToDraw)
    {
        DrawCard(amountToDraw);
    }

    private void DrawCardPlayer(int amountToDraw)
    {
        int drawnCards = 0;
        foreach (GameObject cardSlot in handPlayer.cardSlotsInHand)
        {
            CardDisplay cardDisplay = cardSlot.GetComponent<CardDisplay>();
            if (cardDisplay.card != null) continue;

            if (!cardSlot.activeInHierarchy)
            {
                if (drawnCards >= amountToDraw) break;

                cardDisplay.card = handPlayer.deck.WhichCardToDraw();
                cardSlot.SetActive(true);
                drawnCards++;
            }
        }
    }

    private void DrawCardOpponent(int amountToDraw)
    {
        int drawnCards = 0;
        foreach (GameObject cardSlot in handOpponent.cardSlotsInHand)
        {
            CardDisplay cardDisplay = cardSlot.GetComponent<CardDisplay>();
            if (cardDisplay.card != null) continue;

            if (!cardSlot.activeInHierarchy)
            {
                if (drawnCards >= amountToDraw) break;

                cardDisplay.card = handOpponent.deck.WhichCardToDraw();
                cardSlot.SetActive(true);
                drawnCards++;
            }
        }
    }
}
