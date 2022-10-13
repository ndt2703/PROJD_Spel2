using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public TMP_Text manaText;

    public SpriteRenderer artworkSpriteRenderer;

    private void UpdateTextOnCard()
    {
        if (card == null) return;

        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkSpriteRenderer.sprite = card.artwork;
        manaText.text = card.manaCost.ToString();
    }

    private void FixedUpdate()
    {
        UpdateTextOnCard();
    }
}
