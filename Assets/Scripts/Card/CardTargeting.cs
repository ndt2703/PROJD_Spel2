using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTargeting : MonoBehaviour
{
    private Vector3 startposition;
    private RectTransform gameObjectRectTransform;
    private GameLoop gameLoop;

    private CardDisplay cardDisplay;
    private CardMovement cardMovement;
    private Vector3 mousePosition;
    private Card card;

    private void OnMouseUp()
    {
        mousePosition = cardMovement.mousePosition;
        card = cardDisplay.card;

        RaycastHit hitEnemy;
        Physics.Raycast(mousePosition, Vector3.forward * 5f, out hitEnemy, 10f);
        Debug.DrawRay(mousePosition, Vector3.forward * 5f, Color.red, 100f);

        if (hitEnemy.collider == null)
        {
            CardGoBackToStartingPosition();
            return;
        }

        WhatToDoWhenTargeted(hitEnemy.transform.gameObject);
    }

    private void WhatToDoWhenTargeted(GameObject gameObjectHit)
    {
        switch (gameObjectHit.tag)
        {
            case "Champion":
                card.Target = gameObjectHit.GetComponent<Champion>();
                if (gameLoop.CheckIfCanPlayCard(card))
                    card = null;
                break;
            case "LandmarkSlot":
                if (!gameObject.tag.Equals("Landmark")) return;
                CardDisplay landmark = gameObjectHit.GetComponent<CardDisplay>();
                landmark.card = card;
                card = null;
                break;
        }
    }

    private void CardGoBackToStartingPosition()
    {
        gameObjectRectTransform.anchoredPosition = startposition;
    }


    // Start is called before the first frame update
    void Start()
    {
        gameLoop = GameLoop.Instance;
        cardDisplay = GetComponent<CardDisplay>();
        cardMovement = GetComponent<CardMovement>();

        if (!gameObject.tag.Equals("LandmarkSlot"))
        {
            gameObjectRectTransform = GetComponent<RectTransform>();
            startposition = gameObjectRectTransform.anchoredPosition;
        }
    }
}
