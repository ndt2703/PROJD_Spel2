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

    public Image artworkImage;



    private Vector3 offset;
    private Camera mainCamera;
    //public TMP_Text damageText;

    private GameState gameState;
    private Vector3 mousePosition;


    private void OnMouseDown()
    {
        offset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12)); 
    }

    private void OnMouseDrag()
    {
        if (gameObject.tag.Equals("LandmarkSlot")) return;
        mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12));

        transform.position = mousePosition + offset;
    }

    private void OnMouseUp()
    {
        RaycastHit hitEnemy;
        Physics.Raycast(mousePosition, Vector3.forward * 5f, out hitEnemy, 10f);
        Debug.DrawRay(mousePosition, Vector3.forward * 5f, Color.red, 100f);
        
        if (hitEnemy.collider == null) return;

        GameObject gameobjectHit = hitEnemy.transform.gameObject;

        switch (gameobjectHit.tag)
        {
            case "Champion":
                card.Target = gameobjectHit.GetComponent<Champion>();
                gameState.CheckIfCanPlayCard(card);
                card = null;
                break;
            case "LandmarkSlot":
                Debug.Log("Runs");
                CardDisplay landmark = gameobjectHit.GetComponent<CardDisplay>();
                landmark.card = card;
                card = null;
                break;
        }                                 
    }

    private void UpdateTextOnCard()
    {
        if (card == null) return;

        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artwork;
        manaText.text = card.manaCost.ToString();
    }

    private void FixedUpdate()
    {
        UpdateTextOnCard();
    }


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Instance;
        mainCamera = Camera.main;
    }
}
