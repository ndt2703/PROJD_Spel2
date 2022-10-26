using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CardTargeting : MonoBehaviour
{
    private Vector3 startposition;
    private RectTransform gameObjectRectTransform;
    private ActionOfPlayer actionOfPlayer;

    private CardDisplay cardDisplay;
    private CardMovement cardMovement;
    private Vector3 mousePosition;
    private Card card;
    private Graveyard graveyard;


    private GameObject gameObjectHit;
    

    void Start()
    {
        graveyard = Graveyard.Instance;
        actionOfPlayer = ActionOfPlayer.Instance;
        cardDisplay = GetComponent<CardDisplay>();       

        if (!gameObject.tag.Equals("LandmarkSlot"))
        {
                gameObjectRectTransform = GetComponent<RectTransform>();           
                startposition = gameObjectRectTransform.anchoredPosition;
        }
    }

    private void OnMouseUp()
    {
        cardMovement = GetComponent<CardMovement>();
        mousePosition = cardMovement.mousePosition;
        card = cardDisplay.card;

        if (cardDisplay.opponentCard == true) return;

        RaycastHit hitEnemy;
        Physics.Raycast(mousePosition, Vector3.forward * 5f, out hitEnemy, 10f);
        Debug.DrawRay(mousePosition, Vector3.forward * 5f, Color.red, 100f);

        if (hitEnemy.collider == null)
        {
            CardGoBackToStartingPosition();
            return;
        }
        gameObjectHit = hitEnemy.transform.gameObject;


        if (actionOfPlayer.CheckIfCanPlayCard(card, true))
        {
            GameState.Instance.ShowPlayedCard(card);
            WhatToDoWhenTargeted();
        }            
    }
    private void CardGoBackToStartingPosition()
    {
        gameObjectRectTransform.anchoredPosition = startposition;
        print(gameObjectRectTransform.anchoredPosition);
    }

    private void WhatToDoWhenTargeted()
    {
        if (actionOfPlayer.tauntPlaced > 0)
        {
            if (gameObjectHit.tag.Equals("TauntCard"))
            {
                card.LandmarkTarget = gameObjectHit.GetComponent<LandmarkDisplay>();
                card.PlayCard();
                graveyard.AddCardToGraveyard(card);
                cardDisplay.card = null;                
            }
            return;
        }

        switch (gameObjectHit.tag)
        {
            case "Champion":
                card.Target = gameObjectHit.GetComponent<AvailableChampion>().champion;
                 
                Graveyard.Instance.AddCardToGraveyard(card);
                card.PlayCard();
                cardDisplay.card = null;
                
                break;
            case "LandmarkSlot":
                WhatToDoWhenLandmarkSlotTargeted();
                break;
        }
        
    }

    private void WhatToDoWhenLandmarkSlotTargeted()
    {
        LandmarkDisplay landmarkSlot = gameObjectHit.GetComponent<LandmarkDisplay>();
        Landmarks landmark = null;

        switch (card.tag)
        {
            case "DestroyLandmark":
                card.PlayCard();
                graveyard.AddCardToGraveyard(card);
                cardDisplay.card = null;
                return;
            case "Spell":
                card.LandmarkTarget = landmarkSlot;

                Graveyard.Instance.AddCardToGraveyard(card);
                card.PlayCard();
                cardDisplay.card = null;
                return;
            case "HealingLandmark":
                landmark = new HealingLandmark((HealingLandmark)card); 
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
            case "CultistLandmark":
                landmark = new CultistLandmark((CultistLandmark)card);
                break;
            case "BuilderLandmark":
                landmark = new BuilderLandmark((BuilderLandmark)card);
                break;
        }

        landmarkSlot.health = landmark.minionHealth;    
        landmarkSlot.card = landmark;
        cardDisplay.card = null;
    }


}
