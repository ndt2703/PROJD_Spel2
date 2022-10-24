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
        if (ActionOfPlayer.Instance.tauntPlaced)
        {
            if (gameObjectHit.tag.Equals("TauntCard"))
            {
                card.LandmarkTarget = gameObjectHit.GetComponent<LandmarkDisplay>();
                if (actionofPlayer.CheckIfCanPlayCard(card, true))
                {
                    card.PlayCard();
                    cardDisplay.card = null;
                }
            }
            return;
        }

        switch (gameObjectHit.tag)
        {
            case "Champion":
                card.Target = gameObjectHit.GetComponent<Champion>();
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

        }
        else if (card.tag.Equals("Spell"))
        {

        }

        LandmarkDisplay landmarkSlot = gameObjectHit.GetComponent<LandmarkDisplay>();
        Landmarks landmark = null;
        
        switch (card.tag)
        {
            case "DestroyLandmark":
                LandmarkDisplay landmarkToDestroy = gameObjectHit.GetComponent<LandmarkDisplay>();
                landmarkToDestroy.card = null;
                break;
            case "Spell":
                card.LandmarkTarget = gameObjectHit.GetComponent<LandmarkDisplay>();
                if (actionofPlayer.CheckIfCanPlayCard(card, true))
                {
                    card.PlayCard();
                    cardDisplay.card = null;                   
                }
                break;
            case "HealingLandmark":
                landmark = new HealingLandmark( (HealingLandmark)card );
                break;
            case "TauntLandmark":
                landmark = new TauntLandmark((TauntLandmark)card);
                break;
            case "DamageLandmark":
                landmark = new DamageLandmark((DamageLandmark)card);
                break;
            case "DrawCardLandmark":
                landmark = new DrawCardLandmark((DrawCardLandmark)card);
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
