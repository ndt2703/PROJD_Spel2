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

    public Image artworkImage;

    public TMP_Text manaText;

    private RectTransform rectTransform;

    //public TMP_Text damageText;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        nameText.text = card.name;
        descriptionText.text = card.description;    
        artworkImage.sprite = card.artwork;
        manaText.text = card.manaCost.ToString();
    }
}
