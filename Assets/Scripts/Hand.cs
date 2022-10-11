using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<GameObject> cardSlotsInHand = new List<GameObject>();
    public Deck deck;

    private void FixedUpdate()
    {
        foreach (GameObject cardSlot in cardSlotsInHand)
        {
            CardDisplay cardDisplay = cardSlot.GetComponent<CardDisplay>();
            if (cardDisplay.card != null) continue;
            cardSlot.SetActive(false);
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
