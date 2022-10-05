using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestCard : MonoBehaviour
{
    public bool played = false;
    public void ClickCard()
    {
        played = true;
        GetComponent<Button>().interactable = false;
        FindObjectOfType<PlayerHand>().PlayCard(this.gameObject);
    }
}
