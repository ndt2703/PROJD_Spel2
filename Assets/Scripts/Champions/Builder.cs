using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Builder", menuName = "Champion/Builder", order = 1)]
public class Builder : Champion
{
	private int landmarkCount = 0;
	private int landmarkNeeded = 2;
	private int cardCostReduce = 2;

	public Builder(Builder c) : base(c.name, c.health, c.maxHealth, c.shield, c.artwork, c.passiveEffect, c.mesh)
	{
		landmarkCount = c.landmarkCount;
		landmarkNeeded = c.landmarkNeeded;
		cardCostReduce = c.cardCostReduce;
	}

	public override void Awake()
	{
		base.Awake();
		UpdatePassive();
	}

	public override void AmountOfCardsPlayed()
	{
		base.AmountOfCardsPlayed();

		landmarkCount++;
		UpdatePassive();
		if (landmarkCount >= landmarkNeeded)
		{
			LowerCostOfCardsInHand();

            //every card in hand 
            //minus two
        }
		
	}

	public void LowerCostOfCardsInHand()
	{
        foreach (GameObject gO in ActionOfPlayer.Instance.handPlayer.cardsInHand)
        {
			Card card = gO.GetComponent<CardDisplay>().card;
            card.manaCost -= 2;
			if (card.manaCost < 0)
			{
				card.manaCost = 0;
            }
        }
    }

	public void RaiseCostOfCardsInHand()
	{
        foreach (GameObject gO in ActionOfPlayer.Instance.handPlayer.cardsInHand)
        {
            Card card = gO.GetComponent<CardDisplay>().card;
            card.manaCost += 2;
            if (card.manaCost > card.maxManaCost)
            {
                card.manaCost = card.maxManaCost;

            }
        }
    }

	public override void WhenLandmarksDie()
	{
		base.WhenLandmarksDie();
		landmarkCount--;
		if (landmarkCount < landmarkNeeded)
		{
			RaiseCostOfCardsInHand();

        }
		UpdatePassive();
	}

	public override void DrawCard()
	{
		base.DrawCard();
		if (landmarkCount >= landmarkNeeded)
		{
			//reduce the card drawn by two
		}
	}

	private void UpdatePassive()
	{
		passiveEffect = landmarkCount + "/" + landmarkNeeded;
		
	}

}
