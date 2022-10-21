using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTargeting : MonoBehaviour
{
    private Vector3 startposition;
    private RectTransform gameObjectRectTransform;
    private ActionOfPlayer actionofPlayer;

    private CardDisplay cardDisplay;
    private CardMovement cardMovement;
    private Vector3 mousePosition;
    private Card card;

    private GameObject gameObjectHit;

    void Start()
    {
        actionofPlayer = ActionOfPlayer.Instance;
        cardDisplay = GetComponent<CardDisplay>();
        cardMovement = GetComponent<CardMovement>();

        if (!gameObject.tag.Equals("LandmarkSlot"))
        {
            gameObjectRectTransform = GetComponent<RectTransform>();
            startposition = gameObjectRectTransform.position;
        }
    }

    private void OnMouseUp()
    {
        mousePosition = GetComponent<CardMovement>().mousePosition;
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
        GameState.Instance.ShowPlayedCard(card);
        WhatToDoWhenTargeted();
    }

    private void WhatToDoWhenTargeted()
    {
        switch (gameObjectHit.tag)
        {
            case "Champion":
                card.Target = gameObjectHit.GetComponent<AvailableChampion>();
                if (actionofPlayer.CheckIfCanPlayCard(card, true))
                {                    
                    card.PlayCard();
                    cardDisplay.card = null;
                }
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
            LandmarkDisplay landmarkToDestroy = gameObjectHit.GetComponent<LandmarkDisplay>();
            landmarkToDestroy.card = null;
            return;
        }
        else if (card.tag.Equals("Spell"))
        {
            card.LandmarkTarget = gameObjectHit.GetComponent<LandmarkDisplay>();
            if (actionofPlayer.CheckIfCanPlayCard(card, true))
            {
                card.PlayCard();
                cardDisplay.card = null;
                return;
            }
        }

        LandmarkDisplay landmarkSlot = gameObjectHit.GetComponent<LandmarkDisplay>();
        Landmarks landmark = null;
        
        switch (card.name)
        {
            case "Unicorn Glade":
                landmark = new HealingLandmark( (HealingLandmark)card );
                break;
        }

        landmarkSlot.health = landmark.minionHealth;    
        landmarkSlot.card = landmark;
        cardDisplay.card = null;
    }

    private void CardGoBackToStartingPosition()
    {
        gameObjectRectTransform.anchoredPosition = startposition;
    }
}
