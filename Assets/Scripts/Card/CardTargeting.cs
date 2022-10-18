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

    private GameObject gameObjectHit;

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
        gameObjectHit = hitEnemy.transform.gameObject;
        WhatToDoWhenTargeted();
    }

    private void WhatToDoWhenTargeted()
    {
        switch (gameObjectHit.tag)
        {
            case "Champion":
                card.Target = gameObjectHit.GetComponent<AvailableChampion>();
                if (gameLoop.CheckIfCanPlayCard(card))
                    card = null;
                break;
            case "LandmarkSlot":
                WhatToDoWhenLandmarkSlotTargeted();
                break;
        }
    }

    private void WhatToDoWhenLandmarkSlotTargeted()
    {
        if (card.tag.Equals("DestroyLandmark"))
        {
            CardDisplay landmarkToDestroy = gameObjectHit.GetComponent<CardDisplay>();
            landmarkToDestroy.card = null;
            return;
        }
        else if (!card.tag.Equals("Landmark")) return;

        CardDisplay landmark = gameObjectHit.GetComponent<CardDisplay>();
        landmark.card = card;
        card = null;
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
