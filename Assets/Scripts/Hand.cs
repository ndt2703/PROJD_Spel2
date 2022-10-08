using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<GameObject> cardSlotsInHand = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
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
