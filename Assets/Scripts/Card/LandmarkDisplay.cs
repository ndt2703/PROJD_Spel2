using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LandmarkDisplay : MonoBehaviour
{
    public Landmarks card;
    public SpriteRenderer artworkSpriteRenderer;
    public int health;

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
        health -= amount;

        if (health <= 0)
        {
            LandmarkDead();
            card = null;
            artworkSpriteRenderer.sprite = null;
        }
    }

    private void FixedUpdate()
    {
        UpdateTextOnCard();
    }
}


