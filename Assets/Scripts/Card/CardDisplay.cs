using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TMP_Text manaText;

    public SpriteRenderer artworkSpriteRenderer;

    public GameObject border;

    private void UpdateTextOnCard()
    {
        if (card == null) return;

        if (!card.opponentCard)
            artworkSpriteRenderer.sprite = card.artwork;
        manaText.text = card.manaCost.ToString();
    }

    private void FixedUpdate()
    {
        UpdateTextOnCard();
    }
}
