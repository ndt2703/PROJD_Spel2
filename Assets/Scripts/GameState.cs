using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int playerMana;
    public Hand hand;

    private static GameState instance;

    public static GameState Instance { get { return instance; } set { instance = value; } }
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

    public void DrawCardToHand(int amountToDraw)
    {
        hand.DrawCard(amountToDraw);
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
}
