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

    private void FixedUpdate()
    {
        UpdateTextOnCard();
    }
}


