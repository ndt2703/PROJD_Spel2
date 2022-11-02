using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TMP_Text manaText;

    public MeshRenderer artworkMeshRenderer;

    public GameObject cardPlayableEffect;

    public GameObject border;
    [System.NonSerialized] public bool opponentCard;

    private void UpdateTextOnCard()
    {
        if (card == null) return;
        
        
        if (!opponentCard)
        {
            //artworkMeshRenderer.material = ;

            if (ActionOfPlayer.Instance.currentMana >= card.manaCost)
                cardPlayableEffect.SetActive(true);
            else
                cardPlayableEffect.SetActive(false);
        }
            

        
       
        manaText.text = card.manaCost.ToString();
    }

    private void FixedUpdate()
    {
        UpdateTextOnCard();
    }

    private void OnMouseEnter()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1); 
    }
    private void OnMouseExit()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
    }
}
