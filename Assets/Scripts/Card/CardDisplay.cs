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

    private Vector3 offset;
    private Camera mainCamera;
    //public TMP_Text damageText;


    private void OnMouseDown()
    {
        card.PlayCard();     
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 8));

        //Vector3 offset = transform.position - mousePosition;

        transform.position = mousePosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        nameText.text = card.name;
        descriptionText.text = card.description;    
        artworkImage.sprite = card.artwork;
        manaText.text = card.manaCost.ToString();
    }
}
