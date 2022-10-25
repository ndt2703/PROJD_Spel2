using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LandmarkDisplay : MonoBehaviour
{
    public Landmarks card;
    public SpriteRenderer artworkSpriteRenderer;
    public int health;
    public bool occultGathering = false;
    [NonSerialized] public int tenExtraDamage;
    private GameState gameState;



    private void Start()
    {
        gameState = GameState.Instance;
    }

    private void UpdateTextOnCard()
    {
        if (card == null) return;

        artworkSpriteRenderer.sprite = card.artwork;
    }

    public void DestroyLandmark()
    {
        card = null;
    }

    private void LandmarkDead()
    {
        card.LandmarkEffectTakeBack();
    }

    public void TakeDamage(int amount)
    {
        if (gameState.slaughterhouse > 0)
        {
            for (int i = 0; i < gameState.playerLandmarks.Count; i++)
            {
                amount += 10 * gameState.slaughterhouse;
            }
        }


        if (tenExtraDamage > 0)
        {
            amount += (10 * tenExtraDamage);
        }

        health -= amount + gameState.damageRamp;

        if (health <= 0)
        {
            LandmarkDead();
            Graveyard.Instance.AddCardToGraveyard(card);
            card = null;
            artworkSpriteRenderer.sprite = null;
        }
    }

    private void FixedUpdate()
    {
        if (gameState.amountOfTurns == 10)
        {
            if (card.cardName.Equals("Mysterious Forest"))
            {
                DestroyLandmark();
                gameState.DrawCard(5);
            }
        }
        UpdateTextOnCard();
    }
}


